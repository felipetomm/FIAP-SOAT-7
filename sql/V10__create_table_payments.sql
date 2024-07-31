create table payments (
	id                      bigserial primary key,
	external_transaction_id varchar(255) not null,
	amount                  numeric(10,2) not null,
	status                  int not null,
	gateway                 int not null,
	hash                    uuid null,
	created                 timestamp not null default current_timestamp,
	modified                timestamp null default current_timestamp,
	deleted                 bool default false null
);