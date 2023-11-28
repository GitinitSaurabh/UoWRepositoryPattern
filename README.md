# UoWRepositoryPattern
Demonstrating Unit of Work and Repository pattern for a Product entity

<b>Why use unit of work instead of simply doing CRUD operations and calling the save changes method?</b>

The Unit of Work pattern provides several benefits over directly performing CRUD operations and calling SaveChanges():

Consistency: The Unit of Work pattern ensures that there’s a single, consistent way to apply changes to the database. Without it, developers might call SaveChanges() at different points in the code, leading to inconsistencies.

Atomicity: The Unit of Work pattern groups together changes to the database into a single transaction. This means that either all changes are committed, or none are. Without the Unit of Work pattern, if you perform several operations and call SaveChanges() after each one, some operations might succeed while others fail, leaving the database in an inconsistent state.

Reduced Database Roundtrips: Each call to SaveChanges() is a round trip to the database. If you’re performing several operations, calling SaveChanges() after each one can significantly slow down your application. With the Unit of Work pattern, you can perform all your operations first, and then call SaveChanges() once, reducing the number of database roundtrips.

Ease of Testing: The Unit of Work pattern makes it easier to write unit tests for your code. You can mock the Unit of Work and the Repositories, allowing you to test your business logic without hitting the database.

Decoupling: The Unit of Work pattern decouples your business logic from the underlying data access logic, making your code cleaner and easier to maintain.


<b>How does the complete method keep track of all the databases (ex. Product, Orders, Customer) that need to be updated in a single transaction?</b>
We call _unitOfWork.Complete(). This method calls _context.SaveChanges(), which <u>goes through all the entities being tracked by the DbContext, determines what changes have been made, and generates the necessary SQL commands. These commands are then sent to the database in a single transaction.</u> If any part of this transaction fails (for example, due to a concurrency conflict), none of the changes are committed. If the transaction succeeds, all changes are committed.
