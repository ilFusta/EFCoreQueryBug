# EFCore Query Bug?

This repository has been created to test a potential bug in the way EFCore is generating the query in a specific case.

I'm using an InMemory database provider but I've got the same result with SQLServer provider.

The data model represent a Transaction that can have Multiple related Statements each one is connected to a Contact.

The Statements can be of different types "Client", "Model", "Agency" and each transaction can have multiple Statements for each type.

I'm not using TPH but just filtering on type manually.

The query is trying to get all the Statements of Type "Client" grouped by ContactID and then, for each of them, all the Statements of Type "Model" that are commission and are linked to the same Transaction.

With the preloaded data, the expected result for the ContactID = 1, should be 2 Model Statements, instead it returns 4 duplicating the rows.

