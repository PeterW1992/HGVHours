import 'package:flutter/material.dart';
import 'package:hgv_hours/main.dart';
import 'package:hgv_hours/screens/shifts/new_shift.dart';
import 'package:provider/provider.dart';

class ShiftsPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var appState = context.watch<MyAppState>();

    var shiftsController = appState.shiftsController;

    if (shiftsController.shifts.isEmpty) {
      return ListView(
        children: [
          Text('No shifts yet.'),
          ElevatedButton.icon(
            onPressed: () {
              _dialogBuilder(context);
            },
            label: Text('Add Shift'),
            icon: Icon(Icons.add),
          )
        ],
      );
    }

    return ListView(
      children: [
        Padding(
          padding: const EdgeInsets.all(20),
          child: Text('You have '
              '${shiftsController.shifts.length} shifts:'),
        ),
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
        return SimpleDialog(
          children: [
            DatePickerDialog(
                initialDate: initialDate,
                firstDate: firstDate,
                lastDate: lastDate),
            TextButton(
              style: TextButton.styleFrom(
                textStyle: Theme.of(context).textTheme.labelLarge,
              ),
              child: const Text('Save'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
            TextButton(
              style: TextButton.styleFrom(
                textStyle: Theme.of(context).textTheme.labelLarge,
              ),
              child: const Text('Cancel'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }
}
