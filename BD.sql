Create database pasWORD default charset cp1251;
use pasWORD;

create table users(
id_u int primary key auto_increment,
login varchar(40),
pass varchar(40),
email varchar(40)
);