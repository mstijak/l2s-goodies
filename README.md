GetById.tt
----------
T4 template which generates GetEntityById methods for all tables found in the dbml file.
Template is based on [DamienG's T4 templates for L2S](http://l2st4.codeplex.com/).

Roadmap
-------
- Clone methods -> would be useful for caching scenarios as L2S entities hold reference to DataContext.
- Interfaces -> Generate model interfaces and apply/write functions (possible clone implementation).