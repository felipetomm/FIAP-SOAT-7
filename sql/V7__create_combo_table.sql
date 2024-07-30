create table combos (
	id       bigserial primary key,
	order_id bigserial not null,
	created  timestamp not null default current_timestamp,
	modified timestamp null default current_timestamp,
	deleted  bool default false null,
	hash     uuid null,
	foreign key ( order_id )
		references orders ( id )
);