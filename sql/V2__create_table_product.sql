create table product (
    id bigserial primary key,
    name varchar(255) not null,
    description varchar(255) null,
    price double precision not null,
    quantity integer not null,
    created_at timestamp not null default current_timestamp,
    updated_at timestamp not null default current_timestamp
);
