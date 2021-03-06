﻿using System;
using cn.jpush.api.common;
using cn.jpush.api.push.mode;
using cn.jpush.api.common.resp;
using cn.jpush.api.schedule;

namespace cn.jpush.api.example.Schedule
{
    public class UpdateSchedule : BaseExample
    {
        public static void Main(string[] args)
        {
            PushPayload pushPayload = new PushPayload()
            {
                platform = Platform.all(),
                audience = Audience.all(),
                notification = new Notification().setAlert(ALERT)
            };

            ScheduleClient scheduleclient = new ScheduleClient(app_key, master_secret);
            TriggerPayload triggerConstructor = new TriggerPayload(START, END, TIME_PERIODICAL, TIME_UNIT, FREQUENCY, POINT);
            SchedulePayload schedulepayloadperiodical = new SchedulePayload(NAME, ENABLED, triggerConstructor, pushPayload);
            SchedulePayload putschedulepayload = new SchedulePayload();
            putschedulepayload.setName(NAME);

            try
            {
                var result = scheduleclient.putSchedule(putschedulepayload, SCHEDULE_ID);
                Console.WriteLine(result);
            }
            catch (APIRequestException e)
            {
                Console.WriteLine("Error response from JPush server. Should review and fix it. ");
                Console.WriteLine("HTTP Status: " + e.Status);
                Console.WriteLine("Error Code: " + e.ErrorCode);
                Console.WriteLine("Error Message: " + e.ErrorCode);
            }
            catch (APIConnectionException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
