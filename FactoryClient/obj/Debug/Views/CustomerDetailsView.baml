   M S B A M L   `   `   `  ����  Factory.Client.    (Factory.Client.Views.CustomerDetailsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      a ]Telerik.Windows.Data, Version=2014.2.617.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.617.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2014.2.617.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.617.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m	 iTelerik.Windows.Controls.Docking, Version=2014.2.617.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e
 aTelerik.Windows.Controls, Version=2014.2.617.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.617.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2014.2.617.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Mtelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
   5      .��5      � -   5          �Name$  
LayoutRoot��5       � ColumnDefinitions 5   
   �� 5	      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   $��0��6   $
��Auto��6,   $
��Auto��69   $��2q�6G    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      ��  �� Padding$ 10,10,10,10q�6   ._�5      �� $��1��6    �� Orientation$ Vertical=�6*   .+�5      �� $��Название:��6    $
��Left=�61    �� Padding$ 0,5,5,5q�6L   $
��Bold"�6^   �� 5      $
��Wrap=�6K   ��6    ��  �� Path$ CurrentCustomer.Name�6K   �� 5      $$��Полное название:��6    $
��Left=�68   $ 0,5,5,5q�6S   $
��Bold"�6e   �� 5      $
��Wrap=�6L   ��6    �� $ CurrentCustomer.Descr�6L   �� 5      $��Тел:��6    $
��Left=�6,   $ 0,5,5,5q�6G   $
��Bold"�6Y   �� 5      $
��Wrap=�6L   ��6    �� $ CurrentCustomer.Phone�6L   �� 5       $��Email:��6    $
��Left=�6.   $ 0,5,5,5q�6I   $
��Bold"�6[   �� 5!      $
��Wrap=�6L   ��6    �� $ CurrentCustomer.Email�6L   5"      5#      5$      5&      5'      