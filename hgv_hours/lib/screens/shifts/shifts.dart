import 'package:flutter/material.dart';
import 'package:hgv_hours/main.dart';
import 'package:hgv_hours/screens/shifts/new_shift.dart';
import 'package:provider/provider.dart';

class ShiftsPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var appState = context.watch<MyAppState>();

    var shiftsController = appState.shiftsController;
    shiftsController.listShifts();

    if (shiftsController.shifts.isEmpty) {
      return ListView(
        children: [
          Text('No shifts yet.'),
          ElevatedButton.icon(
            onPressed: () {
              Navigator.of(context).push(MaterialPageRoute(
                builder: (context) => NewShift(),
              ));
              // _dialogBuilder(context);
            },
            label: Text('Add Shift'),
            icon: Icon(Icons.add),
          )
        ],
      );
    }

    return ListView(
      children: [
        for (var shift in shiftsController.shifts)
          ListTile(
            title: Text(shift.startDateTime!.toIso8601String()),
            leading: Icon(Icons.event),
          )
      ],
    );
  }

  Future<void> _dialogBuilder(BuildContext context) {
    return showDialog<void>(
      context: context,
      builder: (BuildContext context) {
        return NewShift();
      },
    );
  }
}
