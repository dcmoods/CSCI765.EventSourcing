using Appointment.CommandStack.Commands;
using Appointment.Domain.Model;
using SharpTestsEx;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Appointment.Domain.Model.AppointmentRequest;

namespace Appointment.Command.Tests.Model
{
    public class AppointmentTests
    {
        [Fact]
        public void Create_should_build_a_valid_instance()
        {
            var roomId = 1;
            var hour = 8;
            var length = 2;
            var name = "fake";
            var note = "fake note";
            var appointment = AppointmentRequest.Factory.Create(roomId, hour, length, name, note);

            Assert.Equal(roomId, appointment.RoomId);
            Assert.Equal(hour, appointment.StartHour);
            Assert.Equal(length, appointment.Length);
            Assert.Equal(name, appointment.Name);
            Assert.Equal(note, appointment.Notes);
            Assert.False(appointment.Completed);
            Assert.NotEqual(Guid.Empty, appointment.Id);
        }

        [Fact]
        public void Create_should_throw_ArgumentException_on_invalid_roomId()
        {
            var roomId = 0;
            var hour = 8;
            var length = 2;
            var name = "fake";
            var note = "fake note";
            Executing.This(() => AppointmentRequest.Factory.Create(roomId, hour, length, name, note))
                .Should()
                .Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("roomId");
        }


        [Fact]
        public void Create_should_throw_ArgumentException_on_invalid_hour()
        {
            var roomId = 1;
            var hour = 6;
            var length = 2;
            var name = "fake";
            var note = "fake note";
            Executing.This(() => AppointmentRequest.Factory.Create(roomId, hour, length, name, note))
                .Should()
                .Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("startHour");
        }

        [Fact]
        public void Create_should_throw_ArgumentException_on_short_length()
        {
            var roomId = 1;
            var hour = 8;
            var length = 0;
            var name = "fake";
            var note = "fake note";
            Executing.This(() => AppointmentRequest.Factory.Create(roomId, hour, length, name, note))
                .Should()
                .Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("length");
        }

        [Fact]
        public void Create_should_throw_ArgumentException_on_long_length()
        {
            var roomId = 1;
            var hour = 8;
            var length = 4;
            var name = "fake";
            var note = "fake note";
            Executing.This(() => AppointmentRequest.Factory.Create(roomId, hour, length, name, note))
                .Should()
                .Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("length");
        }
    }
}
