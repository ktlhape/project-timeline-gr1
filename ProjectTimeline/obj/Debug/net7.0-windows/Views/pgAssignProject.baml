   M S B A M L   `   `   `  ����J  FProjectTimeline, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjectTimeline.ViewsProjectTimeline.Views  5      +    %ProjectTimeline.Views.pgAssignProject   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ProjectTimeline.Views     5        N� Title$  pgAssignProject��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��109* �6   �� 5      $
��230* �6   �� 5      $
��111* �6   .+�5   
   �� $��Select Project��6   $
��Left=�6)   $��	69,42,0,0q�6D   $	��Top=�6W   $��24��6o   $��81��6{   �� 5   
   -   5        $��
cmbProject��5      $
��Left=�6%   $��0��6@   $��
180,35,0,0q�6N   $	��178��6b   $��32��6n   $	��Top=�6z    �� DisplayMemberPath$ ProjectName��5   +    �� SelectedValuePath$
 Code��6K   ��6   �� 5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgvEmployees��5      $��1��6'      AutoGenerateColumns$ False��64      SelectionUnit$ FullRow=�6P      SelectionMode$ Extended=�6h      HeadersVisibility$	 All=�6�      RowHeaderTemplate 5      �� 5      .R�5      �� $��	chkSelect��6   5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6D      Header$ Employee No��6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
EmployeeNo+6O     5      $
 * 6C   $ 	Firstname��6N    6%   �� *	Firstname+6N     5       $
 * 6B   $ Lastname��6M    6%   �� *
Lastname+6M     5!      $
 * 6>   $
 Type��6I    6%   �� *Type+6I   5#      �� 5$   
   -   5        $��btnSave��5$         	b_success#��[  6    $
��SAVE��6C   $
��Left=�6R   $��
115,40,0,0q�6m   $��2��6�   $	��Top=�6�   $��43��6�   $	��130��6�   6�   5&      5'      