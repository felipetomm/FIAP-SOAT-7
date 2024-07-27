create table customer (
    id bigserial primary key,
    cpf varchar(255) not null,
    name varchar(255) not null,
    email varchar(255) null,
    phone varchar(255) null,
    created_at timestamp not null default current_timestamp,
    updated_at timestamp not null default current_timestamp
);

create unique index customer_cpf_idx on customer (cpf);