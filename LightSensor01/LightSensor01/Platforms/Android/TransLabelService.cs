using Android.Hardware;
using Android.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSensor01
{
    internal class TransLabelService : MauiAppCompatActivity, InterfaceTransLabel, ISensorEventListener
    {
        static Label m_label;
        static SensorManager m_sensorManager;
        static Sensor m_Sensor;

        public TransLabelService()
        {

        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
            throw new NotImplementedException();
        }

        public void OnSensorChanged(SensorEvent e)
        {
            m_label.Text = string.Format("Light Value : {0, 8:F3} ", e.Values[0]);
        }

        public void StartSensor()
        {
            m_sensorManager.RegisterListener(this, m_Sensor, SensorDelay.Ui);
        }

        public void StopSensor()
        {
            m_sensorManager.UnregisterListener(this);
        }

        public void TransLightLabel(Label label)
        {
            m_sensorManager = MainActivity.m_sensorManager;
            m_Sensor = m_sensorManager.GetDefaultSensor(SensorType.Light);
            m_label = label;
        }
    }
}
