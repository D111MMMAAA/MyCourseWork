   M S B A M L   `   `   `  ����E  ACourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CourseWork.PagesCourseWork.Pages  5          CourseWork.Pages.StaffMed   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:CourseWork.Pages     5        N� Title$  StaffMed��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value��%  '��       '�� k     �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 11(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$	 100��6&   �� 5       � ��$ 20��6'   5      5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��0.38* �6   �� 5      $��* �6   .+�5   
   � $��1��6    � RowDefinitions 5      �� 5      $��35 �6    �� 5      $��* �6    .+�5      � $��0��6   .+�5       �� -   5        $��Добавить��5       $
��Left=�6,   6G   �� 5!      -   5        $��Изменить��5!      $
��Left=�6,   6G   �� 5"      -   5        $��Удалить��5"      $
��left=�6+   6F   5#      �� 5$      $��1��6   .��5%      &   System.Windows.Controls.DataGrid  -   5          Name$ 
myDatagrid��5%   J      
IsReadOnly$
 True��6   $��Center=�6-   $��1��5&      	   GridLinesVisibility$
	 None=�6#   
   AreRowDetailsFrozen$

 True��5'         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6.      CanUserAddRows$ False��5(         AutoGenerateColumns$ False��6*      Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   ��  �� Path$
 Name�  5+      $  Специальность��6-    6D   �� $ Position�5-      5.      5/      �� 50   
   $��0��6   .+�51      �� $��Фильтрация��6   $��Center=�6*   6I   �� 53      $��Имя��6   6%   �� 54      -   5         ��Name$ NameText��54      6(   �� 55      $ ��Специальность��6   6/   �� 56      -   5        $ SpecText��56      6(   � 57      -   5         �Name$ RowCountPanel��57      $y�Hidden=�6/   .+�58      �� $��Найдено: ��6   $��56��6-   $
��Left=�68   6U   �� 59      -   5         ��Name$ CountRowText��59      $��56��62   5:      5;      5<      5=      