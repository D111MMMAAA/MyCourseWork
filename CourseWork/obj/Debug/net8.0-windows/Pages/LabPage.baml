   M S B A M L   `   `   `  ����E  ACourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CourseWork.PagesCourseWork.Pages  5          CourseWork.Pages.LabPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:CourseWork.Pages     5        N� Title$  LabPage��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value��%  '��       '�� k     �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 11(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$	 100��6&   �� 5       � ��$ 20��6'   5      5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��0.38* �6   �� 5      $��* �6   .+�5   
   � $��1��6    � RowDefinitions 5      �� 5      $��35 �6    �� 5      $��* �6    .+�5      � $��0��6   .+�5       �� -   5        $��Добавить��5       $
��Left=�6,   6G   �� 5!      -   5        $��Изменить��5!      $
��Left=�6,   6G   �� 5"      -   5        $��Удалить��5"      $
��left=�6+   6F   5#      �� 5$      $��2��6   .��5%      &   System.Windows.Controls.DataGrid  -   5          Name$ 
myDatagrid��5%   J      
IsReadOnly$
 True��6   $��Center=�6-   	   GridLinesVisibility$
	 None=�5&      
   AreRowDetailsFrozen$

 True��5'         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6/      CanUserAddRows$ False��5(         AutoGenerateColumns$ False��6+   ��5)      �� *Labs+ 5*      )  #System.Windows.Controls.DataGridRow��%E   '        �� 5+      "  6    .�5,      -   5        5-      5.         Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   ��  �� Path$
 Name�  51      $+ %Количество профилей��6-    6J   �� $ Profiles.Count�  52      $V PКоличество больниц с заключенным договором��6-    6a   �� $ Hospitals.Count�  53      $\ VКоличество поликлиник с заключенным договором��6-    6d   �� $ Policlinics.Count�55      56      57      � 58   
   $��0��6   .+�59      �� .+�5:      �� $��Фильтрация��6   $��Center=�6.   6M   �� 5<      $��Название��6   6.   �� 5=      -   5         ��Name$ NameText��5=      6,   �� 5>      $+��%Количество профилей��6   69   �� 5?      -   5        $ 	CountProf��5?      6-   �� 5@      $M��GКол-во больниц с заключенным договором��6   6L   �� 5A      -   5        $ 	CountHosp��5A      6-   �� 5B      $S��MКол-во поликлиник с заключенным договором��6   6O   �� 5C      -	   5        $ 	CountPoly��5C      6-   � 5D      -
   5         �Name$ RowCountPanel��5D      $y�Hidden=�63   .+�5E      �� $��Найдено: ��6    $��56��61   $
��Left=�6<   6Y   �� 5F      -   5         ��Name$ CountRowText��5F       $��56��66   5G      5H      5I      5J      5K      