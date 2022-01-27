use justasecond;

delete from Orders;
delete from Tables;
delete from OrderPositions;
delete from Products;

insert into Tables(Id, HasCalled)
values
(1, 1);

insert into Orders(Id, CreatedDate, TableId)
values
(1, '2021-01-20', 1);

insert into Products(Id, Title, Price, Description, Type, Image)
values
(1, 'Tuna Sushi', 8.99, 'This is tuna sushi.', 1, 'Sushi.png'),
(2, 'Salmon Sushi', 8.99, 'This is salmon sushi.', 1, 'Sushi_v2.png'),
(3, 'Sushi Mix', 12.99, 'This is sushi mix.', 1, 'Sushi_selection.png');

insert into OrderPositions(Position, OrderId, ProductId)
values
(1, 1, 1),
(2, 1, 2),
(3, 1, 3);