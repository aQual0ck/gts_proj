   M S B A M L   `   `   `  ����>  :GTS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GTS.Pages	GTS.Pages  5          GTS.Pages.PageAdminPhone   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:GTS.Pages     5        N� Title$  PageAdminPhone��5	       N� 
Background �#F6F6F6.��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��50 �6   �� 5      .+�5   
   o� $��0��6   $��Center=�6   .@�5      m� -   5        $��menuAdd��5      $%��Добавить телефон��6&   6@   m� 5      $��Абоненты��6   .@�5      m� -   5        $��menuCustomer��5      $��Абоненты��6/   6A   m� 5      -   5        $��menuGeneral��5      $��
Общее��6.   6=   5      m� 5      -   5        $��
menuChange��5      $��Изменить АТС��6)   5      m� 5      -   5        $��
menuDelete��5      $��Удалить АТС��6)   6>   m� 5      -   5        $��menuBack��5      $��Выбор АТС��6'   6:   m� 5      -   5        $��menuExit��5      $��
Выход��6'   66   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   .+�5      �� -   5        $��	txbSearch��5   9   $	��200��6   $��25��6"   $��5q�6.   5      �� 5       -	   5        $��cmbFilterPT��5       $	��150��6*   $��25��66   5!      �� 5"      -
   5        $��	btnReport��5"   K   $��
Отчет��6   $��75��6%   $��25��60   $��50, 0q�6<   5#      5$      &   System.Windows.Controls.DataGrid  5%   
   -   5        $��dgrPhone��5%      $��2��6#      AutoGenerateColumns .     
IsReadOnly .    Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5)   %   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5(   4   �� *full_number+5)   %     5*      $ 
Адрес��6%   $ * 5+   %   	 5*   4   �� *	address+5+   %   4  .System.Windows.Controls.DataGridTemplateColumn  5,      $ Тип телефона��6)   $ * 6?   
   CellTemplate
 5-      �� 5.      .R�5/      ��  � DataContext 6(   ��  �� Path$ 
phone_type���50   "   �� 51   &   $ phone_type_name�6.   53      54      56        57      $ 
Опции��6)   $ * 68   
 58      �� 59      .R�5:      �� $��Center=�6)   $��Center=�6D   .+�5;   "   �� $��btnEdit��6)   -   5        $ ��Редактировать��5;   8      btnOptionsEdit#��[  5=   )   �� 5>   "   $��	btnDelete��6)   -   5        $��Удалить��5>   :     btnOptionsDelete#��[ 5@   )   �� 5A   "   $��btnViewNumbers��6)   -   5        $��Абоненты��5A   ?     btnOptionsSub#��[ 5C   )   5D      5E      5G      5I      5J      5K      