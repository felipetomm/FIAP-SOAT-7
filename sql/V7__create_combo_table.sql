create table combo (
    id bigserial primary key,
    order_id bigserial not null,
    created_at timestamp not null default current_timestamp,
    updated_at timestamp not null default current_timestamp,
    foreign key (order_id) references customer_order (id)
);