   M S B A M L   `   `   `  ����E  ACourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CourseWork
CourseWork  5   	       CourseWork.AddHospital   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:CourseWork     5   	     � Title$  AddHospital��5   	   $	��870��6   $	��400��6*    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 11(�6)   �� 5       � ��$ Center=�64   5      5      .��5      � 
�������.+�5   
   �� $��Center=�6    �� TextAlignment$ Center=�61   '%Добавление Больницы�� 6]   6j   �� 5   
   $��0��6   $��Center=�6%   .+�5      �� $��Имя��6   6%   �� 5      -   5         ��Name$ NameText��5      �� 5      $��Корпуса��6   6)   �� 5      -   5        $ 	BuildText��5      �� 5      $��Отделения��6   6+   �� 5      -   5        $ 
DepartText��5      �� 5      $��Палаты��6   6(   �� 5      -   5        $ WardText��5      �� 5      $7��1Прикреплённые поликлиники��6   6;   �� 5       -   5         ��Name$ 	PolycList��5        �� SelectionMode$ Multiple=�6)   	 �� DisplayMemberPath$
	 Name��6B   $	��100��6[   �� 5"      $��Доктора��6   6)   �� 5#      -   5        $ DoctList��5#      $ Multiple=�6(   $
	 Name��6A   $	��100��6Z   �� 5%      $��Пациенты��6   6*   �� 5&      -   5        $ PatientList��5&      $ Multiple=�6,   $
	 Name��6E   $	��100��6^   �� 5(      $1��+Обслуживающий персонал��6   68   �� 5)      -   5        $ 
StaffsList��5)      $ Multiple=�6+   $
	 Name��6D   $	��100��6]   $��0, 0, 0, 10q�6j   �� 5+      -	   5        
 ��Name$
 but_add_edit��5+   ;   $��Изменить��6(   6;   5,      5-      5.      