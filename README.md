# Onion LibrarySystem


.Architectural decisions :Onion Architecture , Repository and Unit of Work Pattern using Net 7
Openapi :3.0.1 ,
version :v1,
to run project change server name in connection string in appsetting.json
and delete migration folder and run  command (add-migration) to generate database table(Book-Author-Publisher-BookPublisher)
the relation between tables
(on to many between Author & Book) and many to many between Book and Publisher
