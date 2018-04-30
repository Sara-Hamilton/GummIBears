# Gummi Bears

##### A site for a Gummi Bear Vendor built with Visual Studio MVC, C#, and .NET.  04/20/18

## By Sara Hamilton

# Description
This is the Epicodus weekly project for week 1 of the .NET course.  Its purpose is to display understanding of Visual Studio MVC, ORM, Migrations, and Testing.  

## Functionality
### User Stories
* a user can
  * click on a link on the landing page that takes them to a page that lists all available products
  * click on the link to details for each product and see its details including all reviews and average review rating
  * click on the review link in the navbar to create a review

* an admin can
  * add a product
  * edit a product
  * delete a product
  * delete all products

### Model
  * Product
    * Name
    * Cost
    * Description
    * ImageUrl

  * Review
    * Author
    * Title
    * Content_Body
    * Rating

## Technologies Used
* HTML
* CSS
* Bootstrap
* Visual Studio
* C#
* .NET
* MySql
* MAMP

## Run the Application  

  * _Clone the github respository_
  ```
  $ git clone https://github.com/Sara-Hamilton/GummiBears
  ```

  * _Install the .NET Framework and MAMP_

    .NET Core 1.1 SDK (Software Development Kit)

    .NET runtime.

    MAMP

    See https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c for instructions and links.

* _Start the Apache and MySql Servers in MAMP_

* _Move into the directory_
```
$ cd GummiBears
```
*  _Restore the program_

 ```
 $ dotnet restore
 ```
* _Move one layer deeper into the directory_
```
$ cd GummiBears
```
*  _Setup the database_

 ```
 $ dotnet ef database update --context GummiDbContext
```
*  _Run the program_
```
$ dotnet run
```
## Testing

* _Open project solution in Visual Studio_
=======
* _Move two layers into the directory_
```
$ cd GummiBears/GummiBears
```
*  _Setup the testing database_

 ```
 $ dotnet ef database update --context TestDbContext
```
* _Open project solution in Visual Studio_

*  _Run the tests_

### License

*MIT License*

Copyright (c) 2018 **_Sara Hamilton_**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
