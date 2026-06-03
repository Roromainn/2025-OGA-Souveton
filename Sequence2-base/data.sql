/* données exemples pour la table student */
INSERT INTO `students` VALUES
('1234','Potter','Harry'),
('456','Granger','Hermione'),
('789','Weasley','Ronald')
;

/* données exemples pour la table course */
INSERT INTO `course` VALUES
(100,'Defense against Evil','Dumbledore','2016-01-03 08:00:00',180);

/* données exemples pour la table absence */
INSERT INTO `absence`(`CodeStudent`,`CodeCourse`) VALUES
('1234',100),
('789',100);
