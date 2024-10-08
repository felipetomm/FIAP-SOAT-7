-- Initial SQL for create the database
CREATE SCHEMA IF NOT EXISTS burguerdb;

CREATE TABLE IF NOT EXISTS database_updates (
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    created timestamp,
    content text NOT NULL,
    file_name text NOT NULL,
    CONSTRAINT database_updates_pk PRIMARY KEY (id)
);

CREATE UNIQUE INDEX IF NOT EXISTS unique_file_name_database_updates ON database_updates USING btree (file_name);