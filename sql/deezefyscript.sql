
BEGIN TRANSACTION;
GO

CREATE TABLE [Generos] (
    [Nome] varchar(50) NOT NULL,
    CONSTRAINT [PK_Generos] PRIMARY KEY ([Nome])
);
GO

CREATE TABLE [Locais] (
    [Id] int NOT NULL IDENTITY,
    [Pais] varchar(50) NULL,
    [Cidade] varchar(50) NULL,
    CONSTRAINT [PK_Locais] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Musicas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(50) NULL,
    [Duracao] int NOT NULL,
    CONSTRAINT [PK_Musicas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Playlists] (
    [Nome] varchar(50) NOT NULL,
    CONSTRAINT [PK_Playlists] PRIMARY KEY ([Nome])
);
GO

CREATE TABLE [Usuarios] (
    [Email] varchar(50) NOT NULL,
    [Senha] varchar(50) NULL,
    [DataNascimento] datetime2 NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Email])
);
GO

CREATE TABLE [GeneroMusica] (
    [GenerosNome] varchar(50) NOT NULL,
    [MusicasId] int NOT NULL,
    CONSTRAINT [PK_GeneroMusica] PRIMARY KEY ([GenerosNome], [MusicasId]),
    CONSTRAINT [FK_GeneroMusica_Generos_GenerosNome] FOREIGN KEY ([GenerosNome]) REFERENCES [Generos] ([Nome]) ON DELETE CASCADE,
    CONSTRAINT [FK_GeneroMusica_Musicas_MusicasId] FOREIGN KEY ([MusicasId]) REFERENCES [Musicas] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [MusicaPlaylist] (
    [MusicasId] int NOT NULL,
    [PlaylistsNome] varchar(50) NOT NULL,
    CONSTRAINT [PK_MusicaPlaylist] PRIMARY KEY ([MusicasId], [PlaylistsNome]),
    CONSTRAINT [FK_MusicaPlaylist_Musicas_MusicasId] FOREIGN KEY ([MusicasId]) REFERENCES [Musicas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MusicaPlaylist_Playlists_PlaylistsNome] FOREIGN KEY ([PlaylistsNome]) REFERENCES [Playlists] ([Nome]) ON DELETE CASCADE
);
GO

CREATE TABLE [Artistas] (
    [Email] varchar(50) NOT NULL,
    [NomeArtistico] varchar(50) NULL,
    [Biografia] varchar(50) NULL,
    [AnoFormacao] int NOT NULL,
    CONSTRAINT [PK_Artistas] PRIMARY KEY ([Email]),
    CONSTRAINT [FK_Artistas_Usuarios_Email] FOREIGN KEY ([Email]) REFERENCES [Usuarios] ([Email]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Eventos] (
    [Id] int NOT NULL IDENTITY,
    [Nome] int NOT NULL,
    [EmailOrganizador] varchar(50) NULL,
    CONSTRAINT [PK_Eventos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Eventos_Usuarios_EmailOrganizador] FOREIGN KEY ([EmailOrganizador]) REFERENCES [Usuarios] ([Email]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Ouvintes] (
    [Email] varchar(50) NOT NULL,
    [Nome] varchar(50) NULL,
    [Sobrenome] varchar(50) NULL,
    [Telefone] varchar(50) NULL,
    CONSTRAINT [PK_Ouvintes] PRIMARY KEY ([Email]),
    CONSTRAINT [FK_Ouvintes_Usuarios_Email] FOREIGN KEY ([Email]) REFERENCES [Usuarios] ([Email]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Albuns] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] varchar(50) NULL,
    [AnoLancamento] int NOT NULL,
    [ArtistaEmail] varchar(50) NULL,
    CONSTRAINT [PK_Albuns] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Albuns_Artistas_ArtistaEmail] FOREIGN KEY ([ArtistaEmail]) REFERENCES [Artistas] ([Email]) ON DELETE NO ACTION
);
GO

CREATE TABLE [ArtistaGenero] (
    [ArtistasEmail] varchar(50) NOT NULL,
    [GenerosNome] varchar(50) NOT NULL,
    CONSTRAINT [PK_ArtistaGenero] PRIMARY KEY ([ArtistasEmail], [GenerosNome]),
    CONSTRAINT [FK_ArtistaGenero_Artistas_ArtistasEmail] FOREIGN KEY ([ArtistasEmail]) REFERENCES [Artistas] ([Email]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArtistaGenero_Generos_GenerosNome] FOREIGN KEY ([GenerosNome]) REFERENCES [Generos] ([Nome]) ON DELETE CASCADE
);
GO

CREATE TABLE [ArtistaMusica] (
    [ArtistasEmail] varchar(50) NOT NULL,
    [MusicasId] int NOT NULL,
    CONSTRAINT [PK_ArtistaMusica] PRIMARY KEY ([ArtistasEmail], [MusicasId]),
    CONSTRAINT [FK_ArtistaMusica_Artistas_ArtistasEmail] FOREIGN KEY ([ArtistasEmail]) REFERENCES [Artistas] ([Email]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArtistaMusica_Musicas_MusicasId] FOREIGN KEY ([MusicasId]) REFERENCES [Musicas] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [ArtistaOuvinte] (
    [ArtistasEmail] varchar(50) NOT NULL,
    [OuvintesEmail] varchar(50) NOT NULL,
    CONSTRAINT [PK_ArtistaOuvinte] PRIMARY KEY ([ArtistasEmail], [OuvintesEmail]),
    CONSTRAINT [FK_ArtistaOuvinte_Artistas_ArtistasEmail] FOREIGN KEY ([ArtistasEmail]) REFERENCES [Artistas] ([Email]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArtistaOuvinte_Ouvintes_OuvintesEmail] FOREIGN KEY ([OuvintesEmail]) REFERENCES [Ouvintes] ([Email]) ON DELETE CASCADE
);
GO

CREATE TABLE [MusicaOuvinte] (
    [MusicasId] int NOT NULL,
    [OuvintesEmail] varchar(50) NOT NULL,
    CONSTRAINT [PK_MusicaOuvinte] PRIMARY KEY ([MusicasId], [OuvintesEmail]),
    CONSTRAINT [FK_MusicaOuvinte_Musicas_MusicasId] FOREIGN KEY ([MusicasId]) REFERENCES [Musicas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MusicaOuvinte_Ouvintes_OuvintesEmail] FOREIGN KEY ([OuvintesEmail]) REFERENCES [Ouvintes] ([Email]) ON DELETE CASCADE
);
GO

CREATE TABLE [OuvintePlaylist] (
    [OuvintesEmail] varchar(50) NOT NULL,
    [PlaylistsNome] varchar(50) NOT NULL,
    CONSTRAINT [PK_OuvintePlaylist] PRIMARY KEY ([OuvintesEmail], [PlaylistsNome]),
    CONSTRAINT [FK_OuvintePlaylist_Ouvintes_OuvintesEmail] FOREIGN KEY ([OuvintesEmail]) REFERENCES [Ouvintes] ([Email]) ON DELETE CASCADE,
    CONSTRAINT [FK_OuvintePlaylist_Playlists_PlaylistsNome] FOREIGN KEY ([PlaylistsNome]) REFERENCES [Playlists] ([Nome]) ON DELETE CASCADE
);
GO

CREATE TABLE [Perfis] (
    [Id] int NOT NULL IDENTITY,
    [Informacoes] varchar(50) NULL,
    [OuvinteEmail] varchar(50) NULL,
    CONSTRAINT [PK_Perfis] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Perfis_Ouvintes_OuvinteEmail] FOREIGN KEY ([OuvinteEmail]) REFERENCES [Ouvintes] ([Email]) ON DELETE NO ACTION
);
GO

CREATE TABLE [AlbumMusica] (
    [AlbumsId] int NOT NULL,
    [MusicasId] int NOT NULL,
    CONSTRAINT [PK_AlbumMusica] PRIMARY KEY ([AlbumsId], [MusicasId]),
    CONSTRAINT [FK_AlbumMusica_Albuns_AlbumsId] FOREIGN KEY ([AlbumsId]) REFERENCES [Albuns] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AlbumMusica_Musicas_MusicasId] FOREIGN KEY ([MusicasId]) REFERENCES [Musicas] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AlbumOuvinte] (
    [AlbumsId] int NOT NULL,
    [OuvintesEmail] varchar(50) NOT NULL,
    CONSTRAINT [PK_AlbumOuvinte] PRIMARY KEY ([AlbumsId], [OuvintesEmail]),
    CONSTRAINT [FK_AlbumOuvinte_Albuns_AlbumsId] FOREIGN KEY ([AlbumsId]) REFERENCES [Albuns] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AlbumOuvinte_Ouvintes_OuvintesEmail] FOREIGN KEY ([OuvintesEmail]) REFERENCES [Ouvintes] ([Email]) ON DELETE CASCADE
);
GO

CREATE TABLE [ArtistaPerfil] (
    [ArtistasFavoritosEmail] varchar(50) NOT NULL,
    [PerfisArtistaFavoritoId] int NOT NULL,
    CONSTRAINT [PK_ArtistaPerfil] PRIMARY KEY ([ArtistasFavoritosEmail], [PerfisArtistaFavoritoId]),
    CONSTRAINT [FK_ArtistaPerfil_Artistas_ArtistasFavoritosEmail] FOREIGN KEY ([ArtistasFavoritosEmail]) REFERENCES [Artistas] ([Email]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArtistaPerfil_Perfis_PerfisArtistaFavoritoId] FOREIGN KEY ([PerfisArtistaFavoritoId]) REFERENCES [Perfis] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [GeneroPerfil] (
    [GenerenosFavoritosNome] varchar(50) NOT NULL,
    [GeneroFavoritoPerfisId] int NOT NULL,
    CONSTRAINT [PK_GeneroPerfil] PRIMARY KEY ([GenerenosFavoritosNome], [GeneroFavoritoPerfisId]),
    CONSTRAINT [FK_GeneroPerfil_Generos_GenerenosFavoritosNome] FOREIGN KEY ([GenerenosFavoritosNome]) REFERENCES [Generos] ([Nome]) ON DELETE CASCADE,
    CONSTRAINT [FK_GeneroPerfil_Perfis_GeneroFavoritoPerfisId] FOREIGN KEY ([GeneroFavoritoPerfisId]) REFERENCES [Perfis] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Ocorre](
   [Data] datetime2 NOT NULL,
   [idLocal] int NOT NULL,
   [idEvento]  int NOT NULL,
   [artistaEmail]  varchar(50) NOT NULL,
   CONSTRAINT [PK_Ocorre] PRIMARY KEY ([idLocal], [artistaEmail], [idEvento]),
);
GO


CREATE TABLE [Cria](
   [DataCriacao] datetime2 NOT NULL,
   [PlaylistNome]  varchar(50) NOT NULL,
   [UsuarioEmail]  varchar(50) NOT NULL,
   CONSTRAINT [PK_Cria] PRIMARY KEY ([PlaylistNome]),
   CONSTRAINT [FK_UsuarioCriaPlaylist] FOREIGN KEY ([UsuarioEmail]) REFERENCES [Usuarios]([Email]) ON DELETE CASCADE,
);
GO

CREATE INDEX [IX_AlbumMusica_MusicasId] ON [AlbumMusica] ([MusicasId]);
GO

CREATE INDEX [IX_AlbumOuvinte_OuvintesEmail] ON [AlbumOuvinte] ([OuvintesEmail]);
GO

CREATE INDEX [IX_Albuns_ArtistaEmail] ON [Albuns] ([ArtistaEmail]);
GO

CREATE INDEX [IX_ArtistaGenero_GenerosNome] ON [ArtistaGenero] ([GenerosNome]);
GO

CREATE INDEX [IX_ArtistaMusica_MusicasId] ON [ArtistaMusica] ([MusicasId]);
GO

CREATE INDEX [IX_ArtistaOuvinte_OuvintesEmail] ON [ArtistaOuvinte] ([OuvintesEmail]);
GO

CREATE INDEX [IX_ArtistaPerfil_PerfisArtistaFavoritoId] ON [ArtistaPerfil] ([PerfisArtistaFavoritoId]);
GO

CREATE INDEX [IX_Eventos_EmailOrganizador] ON [Eventos] ([EmailOrganizador]);
GO

CREATE INDEX [IX_GeneroMusica_MusicasId] ON [GeneroMusica] ([MusicasId]);
GO

CREATE INDEX [IX_GeneroPerfil_GeneroFavoritoPerfisId] ON [GeneroPerfil] ([GeneroFavoritoPerfisId]);
GO

CREATE INDEX [IX_MusicaOuvinte_OuvintesEmail] ON [MusicaOuvinte] ([OuvintesEmail]);
GO

CREATE INDEX [IX_MusicaPlaylist_PlaylistsNome] ON [MusicaPlaylist] ([PlaylistsNome]);
GO

CREATE INDEX [IX_OuvintePlaylist_PlaylistsNome] ON [OuvintePlaylist] ([PlaylistsNome]);
GO

CREATE UNIQUE INDEX [IX_Perfis_OuvinteEmail] ON [Perfis] ([OuvinteEmail]) WHERE [OuvinteEmail] IS NOT NULL;
GO

COMMIT;
GO

