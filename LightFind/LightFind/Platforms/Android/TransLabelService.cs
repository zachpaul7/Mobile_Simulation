using Android.Content;
using Android.Hardware;
using Android.Runtime;
using Android.App;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.OS;
using System.Numerics;

namespace LightFind
{
    public class TransLabelService : MauiAppCompatActivity, InterfaceTransLabel, ISensorEventListener
    {
        static Label m_label;
        static SensorManager m_sensorManager;
        static Sensor m_sensor;
        public float brightness;

        public TransLabelService()
        { 

        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
            //throw new NotImplementedException();

        }

        public void OnSensorChanged(SensorEvent e)
        {
            m_label.Text = String.Format("{0,8:F3}", e.Values[0]);
        }

        public void StartSensor()
        {
            //throw new NotImplementedException();
            m_sensorManager.RegisterListener(this, m_sensor, SensorDelay.Ui);
        }

        public void StopSensor()
        {
            m_sensorManager.UnregisterListener(this);

        }

        public void TransLightLabel(Label label)
        {
            m_sensorManager = MainActivity.m_sensorManager;
            m_sensor = m_sensorManager.GetDefaultSensor(SensorType.Light);
            m_label = label;
        }
    }
}
