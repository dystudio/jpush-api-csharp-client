﻿using cn.jpush.api.common;
using cn.jpush.api.push.notification;
using cn.jpush.api.push.mode;
using cn.jpush.api.util;
using cn.jpush.api.schedule;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.jpush.api.schedule
{
    public class SchedulePayload
    {
        private JsonSerializerSettings jSetting;
        private const String NAME = "name";
        private const String ENABLED = "enabled";
        private const String TRIGGER = "trigger";
        private const String PUSH = "push";


        public PushPayload push { get; set; }
        public String name { get; set; }
        public bool enabled { get; set; }
        public Trigger trigger { get; set; }
        public String schedule_id;

        public SchedulePayload()
        {
            name = null;
            enabled = true;
            trigger = null;
            push = null;
            schedule_id = null;
            jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            jSetting.DefaultValueHandling = DefaultValueHandling.Ignore;
        }

        public SchedulePayload(Name name, Enabled enabled, Trigger trigger, PushPayload push)
        {
            schedule_id = null;
            Debug.Assert(name != null);
            Debug.Assert(enabled != null);
            Debug.Assert(trigger != null);
            this.name = name.getName();
            this.enabled = enabled.getEnable();
            this.trigger = trigger;
            this.push = push;
            jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            jSetting.DefaultValueHandling = DefaultValueHandling.Ignore;
        }


        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, jSetting);
        }
        public SchedulePayload Check()
        {
            //Preconditions.checkArgument(!(null == push), "pushpayload should be set.");
            //Preconditions.checkArgument(!(null == name), "name should be set at least one.");
            //Preconditions.checkArgument(!(null == trigger), "trigger should be set.");
            return this;
        }

    }
}