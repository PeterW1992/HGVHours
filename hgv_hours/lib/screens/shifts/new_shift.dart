import 'package:flutter/material.dart';
import 'package:hgv_hours/main.dart';
import 'package:provider/provider.dart';
import 'package:flutter/cupertino.dart';

class NewShift extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var appState = context.watch<MyAppState>();

    var shiftsController = appState.shiftsController;

    DateTime startDate = DateTime.now();
    DateTime startTime = DateTime.now();
    DateTime? endTime;

    final descriptionController = TextEditingController();

    return ListView(
      children: [
        SizedBox(
          height: 200,
          child: CupertinoDatePicker(
            mode: CupertinoDatePickerMode.date,
            initialDateTime: DateTime.now(),
            onDateTimeChanged: (DateTime newDateTime) {
              startDate = newDateTime;
            },
          ),
        ),
        Center(
            child: Text(
          'Start Time',
          style: Theme.of(context).textTheme.labelLarge,
        )),
        SizedBox(
          height: 200,
          child: CupertinoDatePicker(
            mode: CupertinoDatePickerMode.time,
            initialDateTime: DateTime.now(),
            onDateTimeChanged: (DateTime newDateTime) {
              startTime = newDateTime;
            },
          ),
        ),
        Center(
            child: Text(
          'End Time',
          style: Theme.of(context).textTheme.labelLarge,
        )),
        SizedBox(
          height: 200,
          child: CupertinoDatePicker(
            mode: CupertinoDatePickerMode.time,
            initialDateTime: DateTime.now(),
            onDateTimeChanged: (DateTime newDateTime) {
              endTime = newDateTime;
            },
          ),
        ),
        Center(
            child: Text(
          'Description',
          style: Theme.of(context).textTheme.labelLarge,
        )),
        TextField(
          controller: descriptionController,
        ),
        TextButton(
          style: TextButton.styleFrom(
            textStyle: Theme.of(context).textTheme.labelLarge,
          ),
          child: const Text('Save'),
          onPressed: () {
            DateTime startDateTime = DateTime(startDate.year, startDate.month,
                startDate.day, startTime.hour, startTime.minute);

            DateTime? endDateTime = null;

            if (endTime != null) {
              if (endTime!.isBefore(startTime)) {
                endDateTime = DateTime(startDate.year, startDate.month,
                        startDate.day, endTime!.hour, endTime!.minute)
                    .add(Duration(days: 1));
              } else {
                endDateTime = DateTime(startDate.year, startDate.month,
                    startDate.day, endTime!.hour, endTime!.minute);
              }
            }

            shiftsController.addShift(
                startDateTime, endDateTime, descriptionController.text);
          },
        ),
        TextButton(
          style: TextButton.styleFrom(
            textStyle: Theme.of(context).textTheme.labelLarge,
          ),
          child: const Text('Cancel'),
          onPressed: () {
            // shiftsController.addShift()
          },
        )
      ],
    );
  }
}
