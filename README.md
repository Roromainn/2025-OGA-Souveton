Ce projet suit une architecture MVVM.

Ce choix a été fait pour 2 raisons. La premiere est que c'est l'une des 2 seules architectures que nous avons pu expérimenter en cours (avec le MVC, sa variate mère),
l'autre car nous ne l'avons jamais mis en pratique et que c'etait donc une bonne opportunité de tester son implémentation.
Au dela de ca le MVC ainsi que ses variantes est un choix souvent judicieux pour les applications avec des fenetre comme dans notre contexte.

3 projets C# composent la partie client de ce répo github. Le fait de faire 3 projets bien distinct nous oblige a bien faire les séparations entre les couches (M, V, VM) sans triches possibles, afin de respecter au mieux le MVVM ainsi que les principes SOLID

L'approche qui a été décidé de maniere originelle était de creer une vm par partie "logique" de l'application (un etudiant, une absence), puis de le relayer par un controller principal qui lui donnera l'information a la fenetre principale qui communiquera a son tour avec la fenetre concernée.
Comme vous pouvez le constater lors de cette explication ce fonctionnement et non seulement alambiqué mais aussi un cauchemar a implémenter.
C'est ainsi que j'ai changé d'approche pour les VM et comment elle étaient appelées plutot que de remonter par mainview mainvm et d'arriver sur la fonction concerné la VM student par exemple va directement envoyer les informations a la fenetre étudiante.
Ansi la VM pricnipale ne gère plus que la fenetre principale et chacune des VM ne gere plus que sa fenetre dediée. Il peut toutefois avoir des informations qui remontent a plusieur view afin de synchroniser des affichages par la suite.
