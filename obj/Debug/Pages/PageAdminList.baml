   M S B A M L   `   `   `  ����>  :GTS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GTS.Pages	GTS.Pages  5      /clr-namespace:GTS.AuxClassesGTS.AuxClasses  5          GTS.Pages.PageAdminList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:GTS.Pages     5      0classesclr-namespace:GTS.AuxClasses     5        N� Title$  PageAdminList��5
       N� 
Background �#F6F6F6 � 	Resources 5      "   GTS.AuxClasses.BoolConverter   BoolConverter��%   &	          5   
   6    5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��50 �6   �� 5      .+�5   
   o� $��0��6   $��Center=�6   .@�5      m� -   5        $��menuAdd��5      $'��!Добавить абонента��6&   6A   m� 5      $��Телефоны��6   .@�5      m� -   5        $��	menuPhone��5      $��Телефоны��6,   6>   m� 5      -   5        $��menuGeneral��5      $��
Общее��6.   6=   5      m� 5      -   5        $��
menuChange��5      $��Изменить АТС��6)   5      m� 5      -   5        $��
menuDelete��5      $��Удалить АТС��6)   6>   m� 5      -   5        $��menuBack��5      $��Выбор АТС��6'   6:   m� 5      -   5        $��menuExit��5      $��
Выход��6'   66   5       �� 5!   
    �� Orientation$ 
Horizontal=�6   $��1��6.   .+�5"      �� -   5        $��	txbSearch��5"   9   $	��200��6   $��25��6"   $��5q�6.   5#      �� 5$      -	   5        $��cmbFilterCat��5$      $	��150��6+   $��25��67   $��5q�6C   5%      �� 5&      $��0, 2.5, 0, 0q�6   .+�5'      �� -
   5        $��cbDebt��5(      $#��Только должники��5'      $��Center=�65   5(   B   �� 5)      -   5        $��cbIntercity��5*      $*��$Только с межгородом��5)      $��Center=�69   5+      �� 5,      -   5        $
��cbDI��5-   6   $<��6Только без долгов и межгорода��5,      $��Center=�5-      5.   2   5/      �� 50      -   5        $��	btnReport��50   K   $��
Отчет��6   $��75��6%   $��25��60   $��50, 0q�6<   51      52      &   System.Windows.Controls.DataGrid  53   
   -   5        $��dgrCustomer��53      $��2��6&      AutoGenerateColumns .     
IsReadOnly .    Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6K   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 62   �� *name+6K     57      $ Пол��6%   $	 * 6M   
 62   �� *gender+6M     58      $ Возраст��6%   $	 * 6N   
 66   �� *age+6N   4  .System.Windows.Controls.DataGridTemplateColumn  59      $ Категория��6)   $	 * 6<      CellTemplate 5:      �� 5;      .R�5<      ��  � DataContext 6(   ��  �� Path$ category���5=   "   �� 5>   &   $ category_name�6.   5@      5A      5C        5D      $ Долг��6%   $	 * 5E   %   
 5D   3   �� *
has_debt+ �� 	Converter# [  5E   %     5F      $ Межгород��6%   $	 * 5G   %   
 5F   7   �� *has_intercity+# [  5G   %     5H      $ 
Опции��6)   $	 * 68    5I      �� 5J      .R�5K      �� $��Center=�6)   $��Center=�6D   .+�5L   "   �� $��btnEdit��6)   -   5        $ ��Редактировать��5L   8     btnOptionsEdit#��[ 5N   )   �� 5O   "   $��	btnDelete��6)   -   5        $��Удалить��5O   :     btnOptionsDelete#��[ 5Q   )   �� 5R   "   $��btnViewNumbers��6)   -   5        $��Номера��5R   ?     btnOptionsSub#��[ 5T   )   5U      5V      5X      5Z      5[      5\      