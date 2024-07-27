create table combo_item (
	id         bigserial primary key,
	combo_id   bigserial not null,
	product_id bigserial not null,
	quantity   int not null,
	foreign key ( combo_id )
		references combo ( id ),
	foreign key ( product_id )
		references product ( id )
);