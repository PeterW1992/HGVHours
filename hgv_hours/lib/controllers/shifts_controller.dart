import 'dart:convert';

import 'package:hgv_hours/models/shift.dart';
import 'package:hgv_hours/repositories/shifts_repository.dart';
import 'package:http/http.dart' as http;

class ShiftsController {
  List<Shift> shifts = [];

  ShiftsRepository? _shiftsRepository;
  final _baseUrl =
      'https://hgvhours-default-rtdb.europe-west1.firebasedatabase.app/shifts.json/';

  ShiftsController(ShiftsRepository shiftsRepo) {
    _shiftsRepository = shiftsRepo;
  }

  addShift(
      DateTime startDateTime, DateTime? endDateTime, String description) async {
    String? endDateTimeStr;

    if (endDateTime != null) endDateTimeStr = endDateTime.toIso8601String();

    var url = Uri.parse(_baseUrl);
    print(url);
    final response = await http.post(url,
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(<String, String?>{
          'startDateTime': startDateTime.toIso8601String(),
          'endDateTime': endDateTimeStr,
          'description': description
        }));
  }

  listShifts() async {
    List<Shift> shifts = [];

    var url = Uri.parse(_baseUrl);
    final response = await http.get(url, headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
    });
    print(url);
    var map = jsonDecode(response.body);
    print(map.keys);
    for (var key in map.keys) {
      final item = map[key];

      var newShift = Shift();

      newShift.id = key;
      newShift.startDateTime = parseDateTime(item['startDateTime']);
      newShift.endDateTime = parseDateTime(item['endDateTime']);
      newShift.description = item['description'];
      shifts.add(newShift);
    }

    print(shifts);
  }

  parseDateTime(String? dateTime) {
    if (dateTime == null) {
      return null;
    } else {
      return DateTime.parse(dateTime);
    }
  }
}
