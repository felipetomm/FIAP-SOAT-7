create table combo_items (
	id         bigserial primary key,
	combo_id   bigserial not null,
	product_id bigserial not null,
	quantity   int not null,
    created timestamp not null default current_timestamp,
    modified timestamp null default current_timestamp,
    deleted bool default FALSE null,
	foreign key ( combo_id )
		references combos ( id ),
	foreign key ( product_id )
		references products ( id )
);