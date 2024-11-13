-- BookDetails für das Buch "Das Kapital"
INSERT INTO BookDetails (Id, TotalCopies, BorrowedCopies, AvailableCopies) VALUES (1, 10, 2, 8);
-- BookDetails für das Buch "1984"
INSERT INTO BookDetails (Id, TotalCopies, BorrowedCopies, AvailableCopies) VALUES (2, 15, 5, 10);
-- BookDetails für das Buch "Einführung in die Programmierung"
INSERT INTO BookDetails (Id, TotalCopies, BorrowedCopies, AvailableCopies) VALUES (3, 20, 7, 13);
-- BookDetails für die Biografie "Die Biografie von Albert Einstein"
INSERT INTO BookDetails (Id, TotalCopies, BorrowedCopies, AvailableCopies) VALUES (4, 12, 4, 8);
-- BookDetails für das Buch "Der Marsianer"
INSERT INTO BookDetails (Id, TotalCopies, BorrowedCopies, AvailableCopies) VALUES (5, 10, 3, 7);
-- BookDetails für das Buch "Harry Potter und der Stein der Weisen"
INSERT INTO BookDetails (Id, TotalCopies, BorrowedCopies, AvailableCopies) VALUES (6, 25, 10, 15);
-- BookDetails für das Buch "Der Hund von Baskerville"
INSERT INTO BookDetails (Id, TotalCopies, BorrowedCopies, AvailableCopies) VALUES (7, 8, 2, 6);



-- Bücher von existierende Autoren 
-- Bücher von Karl Marx 
INSERT INTO ITEMS (Id, Title, ISBN, PUBLISHED_DATE, ITEM_TYPE, AuthorId) VALUES (1, 'Das Kapital', '978-3-16-148410-0', '1867-09-14', 'NonFiction', 1);
-- Bücher von George Orwell 
INSERT INTO ITEMS (Id, Title, ISBN, PUBLISHED_DATE, ITEM_TYPE, AuthorId) VALUES (2, '1984', '978-0-452-28423-4', '1949-06-08', 'Novel', 2); 
-- Bücher von John Doe 
INSERT INTO ITEMS (Id, Title, ISBN, PUBLISHED_DATE, ITEM_TYPE, AuthorId) VALUES (3, 'Einführung in die Programmierung', '978-3-16-148410-1', '2020-01-01', 'Textbook', 3); 
-- Bücher von Walter Isaacson 
INSERT INTO ITEMS (Id, Title, ISBN, PUBLISHED_DATE, ITEM_TYPE, AuthorId) VALUES (4, 'Die Biografie von Albert Einstein', '978-1-59420-193-0', '2007-10-02', 'Biography', 4); 
-- Bücher von Andy Weir 
INSERT INTO ITEMS (Id, Title, ISBN, PUBLISHED_DATE, ITEM_TYPE, AuthorId) VALUES (5, 'Der Marsianer', '978-3-446-23559-6', '2011-02-11', 'ScienceFiction', 5); 
-- Bücher von J.K. Rowling 
INSERT INTO ITEMS (Id, Title, ISBN, PUBLISHED_DATE, ITEM_TYPE, AuthorId) VALUES (6, 'Harry Potter und der Stein der Weisen', '978-3-7459-9406-7', '1997-06-26', 'Fantasy', 6); 
-- Bücher von Arthur Conan Doyle 
INSERT INTO ITEMS (Id, Title, ISBN, PUBLISHED_DATE, ITEM_TYPE, AuthorId) VALUES (7, 'Der Hund von Baskerville', '978-3-16-148410-8', '1902-04-01', 'Mystery', 7);



-- Bücher von existierende Autoren
-- Bücher von Karl Marx
 INSERT INTO Items (Id, Title, ISBN, PUBLISHED_DATE, ITEM_TYPE, AuthorId) VALUES (8, 'Das Kapital', '978-3-16-148410-0', '1867-09-14', 'NonFiction', 1);
-- Bücher von George Orwell 
INSERT INTO Items (Id, Title, ISBN, PUBLISHED_DATE, ITEM_TYPE, AuthorId) VALUES (9, '1984', '978-0-452-28423-4', '1949-06-08', 'Novel', 2);
--  Bücher von John Doe 
 INSERT INTO Items (Id, Title, ISBN, PUBLISHED_DATE, ITEM_TYPE, AuthorId) VALUES (10, 'Einführung in die Programmierung', '978-3-16-148410-1', '2020-01-01', 'Textbook', 3);
-- Bücher von Walter Isaacson 
INSERT INTO Items (Id, Title, ISBN, PUBLISHED_DATE, ITEM_TYPE, AuthorId) VALUES (11, 'Die Biografie von Albert Einstein', '978-1-59420-193-0', '2007-10-02', 'Biography', 4);
-- Bücher von Andy Weir INSERT INTO Items (Id, Title, ISBN, PublishedDate, BookType, AuthorId) VALUES (5, 'Der Marsianer', '978-3-446-23559-6', '2011-02-11', 'ScienceFiction', 5); 
-- Bücher von J.K. Rowling 
INSERT INTO Items (Id, Title, ISBN, PUBLISHED_DATE, ITEM_TYPE, AuthorId) VALUES (12, 'Harry Potter und der Stein der Weisen', '978-3-7459-9406-7', '1997-06-26', 'Fantasy', 6);
-- Bücher von Arthur Conan Doyle 
INSERT INTO Items (Id, Title, ISBN, PUBLISHED_DATE, ITEM_TYPE, AuthorId) VALUES (13, 'Der Hund von Baskerville', '978-3-16-148410-8', '1902-04-01', 'Mystery', 7);


-- Beispielhafte Ausleihe-Daten in die BookLoan-Tabelle
-- Kunde leiht ein Buch aus
INSERT INTO BookManagement (CustomerId, BookId, LoanDate, DueDate, LibrarianId) VALUES (1, 1, '2024-01-10', '2024-02-10', 2);
-- Ein weiteres Beispiel mit Rückgabedaten
INSERT INTO BookManagement (CustomerId, BookId, LoanDate, DueDate, LibrarianId, ReturnDate, ReturnLibrarianId) VALUES (2, 3, '2024-02-01', '2024-02-28', 1, '2024-02-20', 3);
-- Noch eine Ausleihe ohne Rückgabedatum
INSERT INTO BookManagement (CustomerId, BookId, LoanDate, DueDate, LibrarianId) VALUES (3, 2, '2024-02-15', '2024-03-15', 2);
-- Rückgabe eines anderen Buches
INSERT INTO BookManagement (CustomerId, BookId, LoanDate, DueDate, LibrarianId, ReturnDate, ReturnLibrarianId) VALUES (1, 4, '2024-03-05', '2024-04-05', 3, '2024-03-25', 1);

