   M S B A M L   `   `   `  ����I  EService Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Service_ReaderService_Reader  5      #    Service_Reader.ServiceDayView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Service_Reader     5      -   5          >�Name$  UcServiceDayView��5   s   $��5q�6>   
���   �$	��0.5q�6]   .��5	      9� -   5         9�Name$ 
LayoutRoot��5	      ��5
   
   �� 5      ��6   �� *ReportDateAndDay+.��5   
   � $��Disabled=�6   {�6C   �� *ParentServiceSheetVM.EditMode+ � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��2* �6   .+�5!   
   �� $
��Date��6   $��0��6   $��0��6/   (  "System.Windows.Controls.DatePicker  5"      -   5        $��1��5"      $��0��6)      SelectedDate 66   �� *
DtReport+6X   �� 5#   
   $��Travel Start��6   $��0��6'   $��1��67   �� 5$   
   $��Arrival Onsite��6   $��1��6)   $��1��69   �� 5%   
   $��Depart Site��6   $��2��6&   $��1��66   �� 5&   
   $��
Travel End��6   $��3��6%   $��1��65   :  4System.Windows.Controls.Primitives.DatePickerTextBox  5'   
   $��0��6   $��2��6,   $��5q�69   ��6D   �� *TravelStartTime+  5(   
   -   5        $��txtArrivalOnsite��5(      $��1��64   $��2��6D   $��5q�6Q   ��6\   �� *ArrivalOnsiteTime+  5)      -   5        $��txtDepartSite��5)       $��2��65   $��2��6E   $��5q�6R   ��6]   �� *DepartureSiteTime+  5*   
   -   5        $��txtTravelEnd��5*      $��3��60   $��2��6@   $��5q�6M   ��6X   �� *TravelEndTime+�� 5+   
   $��Mileage��6   $��0��6"   $��3��62   �� 5,   
   $��Daily Allowance��6   $��1��6*   $��3��6:   �� 5-   
   $��Overnight Allowance��6   $��2��6.   $��3��6>   �� 5.   
   $��Barrier Payment��6   $��3��6*   $��3��6:   �� 5/   
   -   5        $��
txtMileage��5/      $��0��6$   $��4��64   $��5q�6A   ��6L   �� *	Mileage+�� 50   
   $��1��6   $��4��6#   $��5q�60    d� 	IsChecked 6;   �� *DailyAllowance+�� 51   
   $��2��6   $��4��6#   $��5q�60    6;   �� *OvernightAllowance+�� 52   
   $��3��6   $��4��6#   $��5q�60    6;   �� *BarrierPayment+�� 53   
   $��Travel time to site��6   $��0��6.   $��5��6>   �� 54   
   $��Travel time from site��6   $��1��60   $��5��6@   �� 55   
   $��Total travel��6   $��2��6'   $��5��67   �� 56   
   $��Total time onsite��6   $��3��6,   $��5��6<   �� 57   
   -   5        $��txtTotalTravelToSite��57      $��0��6.   $��6��6>   $��5q�6K    �� 
IsReadOnly . ��6V   �� *TravelTimeToSite+6x   �� 58   
   -	   5        $��txtTotalTravelFromSite��58      $��1��60   $��6��6@   $��5q�6M    . ��6X   �� *TravelTimeFromSite+6|   �� 59   
   -
   5        $��txtTotalTravelTime��59      $��2��6,   $��6��6<   $��5q�6I    . ��6T   �� *TotalTravelTime+6u   �� 5:      -   5        $��txtTotalTimeOnsite��5:      $��3��60   $��6��6@   $��5q�6M    . ��6X   �� *TotalOnsiteTime+6y   �� 5;   
   $��Daily Report��6   $��0��6'   $��7��67   �� 5<   
   -   5        $��txtDailyReport��5<      $��0��6(   $��8��68   $��5q�6E   $	��500��6P    �� 	IsEnabled . $
��Left=�6x    �� AcceptsReturn . $��4��6�   	 �� TextWrapping$
	 Wrap=�6�   ��6�   �� *DailyReport+�� 5=   
   $��Parts Supplied��6   $��0��6)   $��9��69   �� 5>      -   5        $��txtPartsSupplied��5>      $��0��6.   $��10��6>   $��5q�6L   $	��500��6W   $
��Left=�6c    . $��4��6�   $
	 Wrap=�6�    . ��6�   �� *PartsSuppliedToday+6�   5?      5@      5A      