   M S B A M L   `   `   `  ����J  FProjectTimeline, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjectTimeline.ViewsProjectTimeline.Views  5      $    ProjectTimeline.Views.pgFilter   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ProjectTimeline.Views     5        N� Title$  Filter��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��101* �6   �� 5      $
��349* �6   .+�5   
   �� $��
Filter By:��6   $��20(�6%   $
��Left=�63   $��	34,39,0,0q�6N   $	��Top=�6a   �� 5   
   -   5        $��
cmbOptions��5      $
��Left=�6%   $��
137,50,0,0q�6@   $	��Top=�6T   $	��120��6l   .@�5      �� $��All Projects��6   �� 5      $��Get Project��6   �� 5      $��	Completed��6   �� 5      $��Between Dates��6   �� 5      $��	Six Weeks��6   5      �� 5   
   -   5         ��Name$ 	btnSearch��5      $��Search��6$      	b_success#��[  65   $��606,29,0,32q�6X   $
��Left=�6m   $��84��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgvDisplay��5      $��1��6'      AutoGenerateColumns$ False��64      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Code��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Code+  5      $ Project Name��6%   $ * 6;    6E   �� *ProjectName+  5      $ 
Start Date��6%   $ * 69    6C   �� *	StartDate+	 �� StringFormat$	 {0:dd/MM/yyyy}��  5      $ End Date��6%   $ * 67    6A   �� *	EndDate+$	 {0:dd/MM/yyyy}��  5       $ Duration��6%   $ * 67    6A   �� *
Duration+  5!      $ Estimated Cost��6%   $ * 6=    6G   �� *EstimatedCost+$	 C��5$      �� 5%   
   -   5        $��txtCode��5%      $y�Hidden=�6!   $
��Left=�65   $��
325,50,0,0q�6P   
 �� TextWrapping$

 Wrap=�6d   $	��Top=�6x   $	��120��6�   $��22��6�   5(      5)      