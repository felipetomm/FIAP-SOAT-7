create table customer_order (
    id bigserial primary key,
    order_value numeric(10, 2) not null,
    customer_id bigserial not null,
    status varchar(255) not null,
    time_estimate int not null,
    created_at timestamp not null default current_timestamp,
    updated_at timestamp not null default current_timestamp,
    foreign key (customer_id) references customer (id)
);