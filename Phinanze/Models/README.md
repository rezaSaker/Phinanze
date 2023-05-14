## Model Usage, Maintenance, and Extension Guide

The model is designed to separate the data retrieving and processing functionality of the app from the core application logic and provide a simple way to integrate new models without having to configure its connection to the database or CRUD operations. Read below for details.


### Adding New Models Basics
To create a new Model, you need to create a model class in the `Phinanze.Models` folder and create a dedicated repository class (eg. `ModelNameRepository.cs`). Your model class should implement the `IModel` interface and extend the dedicated repository class. Your dedicated repository class should extend the base repository class `Respository.cs`. 

The model class will automatically have an Id property of type int as a primary key, so you only need to define other model-specific properties in the model class. Your model-specific repository class only needs to contain the following line of code to provide basic CRUD functionality to your model.

    public Repository<ModelName> Get => new Repository<ModelName>();

While the above line of code is enough, for performance enhancement, you can replace the above code with the following code which will allow storing and using a local copy of your database entries for the associated model. 

    private static Repository<ModelName> _repository;
    public static Repository<ModelName> Get
    {
         get
         {
              if(_repository == null)
              {
                   _repository = new Repository<ModelName>();
              }
              return _repository;
          }
     }

You can add more functionalities in your repository or override default functionalities depending on the need of your model. You can also define relationship methods in the repository class. 
Note: Your repository class should not declare any public properties (eg. string Name, or Schools { get; set; }). If you must need it, for example, to get another model in a relationship, you can use methods such as `School() { return _schools }`.

### Validations
Your model will be automatically validated based on your `DataAnnotation` validation rules in the model class. If you need to define custom validators, you can define them in the `Models.Validations.CustomValidations.cs` class and they will be validated automatically before DB insert operation. 

### Usage
 - Get all entries of model Category from the associated DB table: `Category.Get.All()`
 - Find an entry of model Category by id: `Category.Get.One(12)`
 - Find an entry of model Category by other column values: `Category.Get.Where("type", "Earning");`. The first parameter must match the column name in DB table. `Where()` operations will always look for the entry in the DB regardless of whether you chose to utilize a local copy of DB entries through your repository configuration (see repository configuration approach 2 above). Therefore, if you want to utilize the local copy of DB entries instead of making an API request, you can use the LINQ queries instead of performing a `Where()` operation. For example, the above `Where()` operation could be written as this `Category.Get.All().FindAll(e => e.Type == "Earning");`
 - Save a new Category:  `Category c = new() { Name = "Shopping", Type="Expense" }; c.Save();`
 - Update a category: `category c = Category.Get.One(12); c.Type = "Earning"; c.Save();`
 - Delete a Category: `Category.Get.One(12).Delete();`