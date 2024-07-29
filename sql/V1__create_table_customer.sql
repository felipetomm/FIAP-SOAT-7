create table customers (
    id bigserial primary key,
    cpf varchar(255) not null,
    name varchar(255) not null,
    email varchar(255) null,
    phone varchar(255) null,
    created timestamp not null default current_timestamp,
    modified timestamp null default current_timestamp,
    deleted bool default FALSE null
);

create unique index customer_cpf_idx on customers (cpf);