   M S B A M L   `   `   `  ����J  FProjectTimeline, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjectTimeline.ViewsProjectTimeline.Views  5      %    ProjectTimeline.Views.pgCapture   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ProjectTimeline.Views     5        N� Title$  Capture Project��5	      .��5      � 
�������.+�5   
   �� $��Project Code��6   $
��Left=�6'   $��	46,21,0,0q�6B   $	��Top=�6U   $��18(�6m   �� 5   
   -   5         ��Name$ txtCode��5      $
��Left=�6#   $��	46,57,0,0q�6>    �� TextWrapping$
 Wrap=�6Q   $	��Top=�6e   $	��202��6}   $��18(�6�   6�   �� 5   
   $��Project Name��6   $
��Left=�6'   $��
400,21,0,0q�6B   $	��Top=�6V   $��18(�6n   �� 5   
   -   5        $ txtProjectName��5      $��
400,63,0,0q�6*   $
 Wrap=�6>   $	��Top=�6R   $��18(�6j   $
��Left=�6x   $	��202��6�   �� 5   
   $��
Start Date��6   $
��Left=�6%   $��
46,114,0,0q�6@   $	��Top=�6T   $��18(�6l   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dtpStartDate��5      $
��Left=�6)   $��
46,156,0,0q�6D   $	��Top=�6X   $��18(�6p   $	��202��6~   �� 5   
   $��End Date��6   $
��Left=�6#   $��400,114,0,0q�6>   $	��Top=�6S   $��18(�6k     5   
   -   5          Name$ 
dtpEndDate��5      $
��Left=�6)   $��400,156,0,0q�6D   $	��Top=�6Y   $��18(�6q   $	��202��6   �� 5   
   $��Duration��6   $
��Left=�6#   $��
51,280,0,0q�6>   $	��Top=�6R   $��18(�6j   �� 5   
   -   5        $ txtDuration��5      ${�False��6'   $��
46,322,0,0q�69   $
 Wrap=�6M   $	��Top=�6a   $��18(�6y   $
��Left=�6�   $	��202��6�   �� 5   
   $��Estimated Cost��6   $
��Left=�6)   $��400,280,0,0q�6D   $	��Top=�6Y   $��18(�6q   �� 5   
   -   5        $ 
txtEstCost��5      ${�False��6&   $��400,322,0,0q�68   $
 Wrap=�6M   $	��Top=�6a   $��18(�6y   $
��Left=�6�   $	��202��6�   �� 5   
   -   5        $��btnSave��5      ${�False��6    $
��SAVE��62   $
��Left=�6A   $��
46,377,0,0q�6\      	b_success#��[  6p   6�   �� 5   
   $��Hourly Rate��6   $
��Left=�6&   $��46,0,0,0q�6A   $��Center=�6S   $��18(�6n   �� 5   
   -   5        $ txtRate��5      $��
46,249,0,0q�6#   $
 Wrap=�67   $	��Top=�6K   $��18(�6c   $
��Left=�6q   $	��202��6�   5      5      