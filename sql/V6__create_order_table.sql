create table orders (
	id            bigserial primary key,
	order_value   numeric(10,2) not null,
	customer_id   bigserial not null,
	status        int not null,
	time_estimate int not null,
	created       timestamp not null default current_timestamp,
	modified      timestamp null default current_timestamp,
	deleted       bool default false null,
	hash          uuid null,
	foreign key ( customer_id )
		references customers ( id )
);