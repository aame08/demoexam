create database demo2;
use demo2;

create table roles (
  role_id int primary key auto_increment,
  role_name varchar(100) not null
);

create table users (
  user_id int primary key auto_increment,
  surname_user varchar(100) not null,
  name_user varchar(100) not null,
  patronymic_user varchar(100) not null,
  login_user text not null,
  password_user text not null,
  role_user int not null,
  foreign key (role_user) references roles(role_id) 
);

create table manufacturers (
	manufacturer_id int primary key auto_increment,
    manufacturer_name varchar(100) not null
);

create table suppliers (
	supplier_id int primary key auto_increment,
    supplier_name varchar(100) not null
);

create table productTypes (
	type_id int primary key auto_increment,
    type_name varchar(100) not null
);

create table products (
  articleNumber_product nvarchar(100) primary key,
  name_product text not null,
  unit_product varchar(10) not null,
  cost_product int not null,
  maxDiscount_product int not null,
  manufacturer_id int not null,
  supplier_id int not null,
  type_id int not null,
  discountAmount_product decimal(2,1) not null,
  quantityInStock_product int not null,
  description_product text not null,
  photo_product text not null,
  foreign key (manufacturer_id) references manufacturers(manufacturer_id),
  foreign key (supplier_id) references suppliers(supplier_id),
  foreign key (type_id) references productTypes(type_id)
);

create table pickupPoint (
	point_id int primary key auto_increment,
    point_index int not null,
    point_city varchar(100) not null,
    pointn_street varchar(100) not null,
    point_home varchar(10)
);

create table orders (
  order_id int primary key auto_increment,
  order_date date not null,
  order_deliveryDate date not null,
  point_id int not null,
  surname_client varchar(100),
  name_client varchar(100),
  patronymic_client varchar(100),
  receipt_code int not null,
  order_status text not null,
  foreign key (point_id) references pickupPoint(point_id)
);
create table OrderProducts (
  order_id int not null,
  articleNumber_product nvarchar(100)  not null,
  count_product int not null,
  primary key (order_id, articleNumber_product),
  foreign key (order_id) references orders(order_id),
  foreign key (articleNumber_product) references products(articleNumber_product)
);