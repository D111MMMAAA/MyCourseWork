   M S B A M L   `   `   `  ����E  ACourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CourseWork.PagesCourseWork.Pages  5      "    CourseWork.Pages.PatientPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:CourseWork.Pages     5        N� Title$  PatientPage��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value��%  '��       '�� k     �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 11(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$	 100��6&   �� 5       � ��$ 20��6'   5      5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��0.38* �6   �� 5      $��* �6   .+�5   
   � $��1��6    � RowDefinitions 5      �� 5      $��35 �6    �� 5      $��* �6    .+�5      � $��0��6   .+�5       �� -   5        $��Добавить��5       $
��Left=�6,   6G   �� 5!      -   5        $��Изменить��5!      $
��Left=�6,   6G   �� 5"      -   5        $��Удалить��5"      $
��left=�6+   6F   5#      �� 5$      $��1��6   .��5%      &   System.Windows.Controls.DataGrid  -   5          Name$ 
myDatagrid��5%   J      
IsReadOnly$
 True��6   $��Center=�6-   $��1��5&      	   GridLinesVisibility$
	 None=�6    
   AreRowDetailsFrozen$

 True��5'         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6.      CanUserAddRows$ False��5(         AutoGenerateColumns$ False��6*      Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   ��  �� Path$
 Name�  5+      $ Палата��6-    6=   �� $ Position�  5,      $' !Время поступления��6-    6H   �� $ AdmissionDate�  5-      $ Состояние��6-    6@   �� $ 	Condition�  5.      $ Температура��6-    6B   �� $ Temperature�  5/      $! Лечащий доктор��6-    6E   �� $ AttendingDoctor.Name�51      52      53      �� 54   
   $��0��6   .+�55      �� $��Фильтрация��6   $��Center=�6*   6I   �� 56      $��Имя��6   6%   �� 57      -   5         ��Name$ NameText��57      6(   �� 58      $��Палата��6   6(   �� 59      -   5        $ WardText��59      6(   �� 5:      $'��!Время поступления��6   63   �� 5;      -   5        $ DataText��5;      6(   �� 5<      $��Состояние��6   6+   �� 5=      -   5        $ ConText��5=      6'   �� 5>      $��Температура��6   6-   �� 5?      -	   5        $ 	TempeText��5?      6)   �� 5@      $!��Лечащий доктор��6   60   �� 5A      -
   5        $ NameDoctorText��5A      6.   � 5C      -   5         �Name$ RowCountPanel��5C      $y�Hidden=�6/   .+�5D      �� $��Найдено: ��6   $��56��6-   $
��Left=�68   6U   �� 5E      -   5         ��Name$ CountRowText��5E      $��56��62   5F      5G      5H      5I      