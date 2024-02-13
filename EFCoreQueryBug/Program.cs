using Microsoft.EntityFrameworkCore;
using EFCoreQueryBug;

using MyDbContext db = new();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

var results = await db.Statements
    .Where(s => s.Type == "Client")
    .GroupBy(s => s.ContactId)
    .Select(s => new
    {
        ContactId = s.Key,
        ContactName = s.First().Contact.Name,
        ClientStatements = s.Select(st => new
            {
                st.ContactId,
                st.Type,
                st.Name,
                st.Amount,
                st.IsCommission
            }).ToList(),
        ModelStatements = s.SelectMany(st => st.Tramsaction.Statements)
                            .Where(st => st.Type == "Model" && st.IsCommission)
                                .Select(st => new 
                                    { 
                                        st.ContactId, 
                                        st.Type, 
                                        st.Name, 
                                        st.Amount,
                                        st.IsCommission
                                    }).ToList(),
        AgencyStatements = s.SelectMany(st => st.Tramsaction.Statements)
                            .Where(st => st.Type == "Agency")
                                .Select(st => new
                                {
                                    st.ContactId,
                                    st.Type,
                                    st.Name,
                                    st.Amount,
                                    st.IsCommission
                                }).ToList(),
    }).ToListAsync();

int contact1ModelStatements = results
                        .Where(x => x.ContactId == 1)
                        .First()
                        .ModelStatements.Count();

Console.WriteLine($"Expected result: 2 - Actual result: {contact1ModelStatements}");

