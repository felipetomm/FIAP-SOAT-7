INSERT INTO
    customers (
        cpf,
        name,
        email,
        phone,
        created,
        modified,
        hash
    )
VALUES
    (
        '00000000019',
        'Não Identificado',
        'burguer-adm@burguer.com',
        NULL,
        '2024-05-01 00:00:00.000',
        '2024-05-01 00:00:00.000',
        gen_random_uuid()
    );