CREATE TABLE [Empleado] (
    [Id] int NOT NULL IDENTITY,
    [FullName] nvarchar(30) NOT NULL,
    [Position] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_Empleado] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Sala] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(80) NOT NULL,
    [Description] nvarchar(300) NOT NULL,
    [Capacity] int NOT NULL,
    [Available] bit NOT NULL,
    CONSTRAINT [PK_Sala] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Reserva] (
    [Id] int NOT NULL IDENTITY,
    [ReservationDate] datetime2 NOT NULL,
    [ReservedBy] int NOT NULL,
    [MeetinRoomId] int NOT NULL,
    [EmployeeId] int NOT NULL,
    [MeetingRoomId] int NOT NULL,
    CONSTRAINT [PK_Reserva] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reserva_Empleado_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Empleado] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reserva_Sala_MeetingRoomId] FOREIGN KEY ([MeetingRoomId]) REFERENCES [Sala] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Asistente] (
    [Id] int NOT NULL IDENTITY,
    [ReservationId] int NULL,
    [EmployeeId] int NOT NULL,
    [DidAssist] bit NOT NULL,
    CONSTRAINT [PK_Asistente] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Asistente_Empleado_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Empleado] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Asistente_Reserva_ReservationId] FOREIGN KEY ([ReservationId]) REFERENCES [Reserva] ([Id])
);
GO


CREATE INDEX [IX_Asistente_EmployeeId] ON [Asistente] ([EmployeeId]);
GO


CREATE INDEX [IX_Asistente_ReservationId] ON [Asistente] ([ReservationId]);
GO


CREATE INDEX [IX_Reserva_EmployeeId] ON [Reserva] ([EmployeeId]);
GO


CREATE INDEX [IX_Reserva_MeetingRoomId] ON [Reserva] ([MeetingRoomId]);
GO


