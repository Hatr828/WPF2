   M S B A M L   `   `   `  ����  WpfApp1    WpfApp1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Task Management��5   	   $	��600��6!   $	��800��6.   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��3* �6   .+�5   
   ��  �� DisplayMemberPath$
 Name��6a   $��0��6z   $��0��6�   ��6   �� *PagedProjects+ �� SelectedItem 68   �� *SelectedProject+6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��0��6;   .+�5      �� $��Add Project��6   ��6+   �� *AddProjectCommand+�� 5      $��Edit Project��6   ��6,   �� *EditProjectCommand+�� 5      $��Delete Project��6   ��6.   �� *DeleteProjectCommand+�� 5      $��Previous��6   ��6(   �� *PreviousPageCommand+�� 5      $
��Next��6   ��6$   �� *NextPageCommand+5      �� 5   
   $��0��6W   $��1��6d   ��6   �� *Tasks+ 61   �� *SelectedTask+ �� View 5      �� 5      .P�5      �� $
��Name��6%    �� DisplayMemberBinding 63   �� *Name+�� 5      $��Description��6%    6:   �� *Description+�� 5      $��Priority��6%    67   �� *
Priority+�� 5       $��	Completed��6%    68   �� *IsCompleted+5!      5#      �� 5$   
   $ 
Horizontal=�6   $��1��6.   $��1��6;   .+�5%      �� $��Add Task��6   ��6(   �� *AddTaskCommand+�� 5&      $��	Edit Task��6   ��6)   �� *EditTaskCommand+�� 5'      $��Delete Task��6   ��6+   �� *DeleteTaskCommand+5(      5)      5*      