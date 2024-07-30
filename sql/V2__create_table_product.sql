create table products (
	id          bigserial primary key,
	name        varchar(255) not null,
	description varchar(255) null,
	price       double precision not null,
	quantity    integer not null,
	hash        uuid null,
	created     timestamp not null default current_timestamp,
	modified    timestamp null default current_timestamp,
	deleted     bool default false null
);