using Android.Hardware;
using Android.Runtime;
using Android.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempSensor
{
    public class Celsius : MauiAppCompatActivity, InterfaceCelsius, ISensorEventListener2
    {
        MauiService m_mauiService;
        SensorManager m_sensorManager;
        Sensor m_sensor;

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
            //throw new NotImplementedException();
        }

        public void OnFlushCompleted(Sensor sensor)
        {
            throw new NotImplementedException();
        }

        public void OnSensorChanged(SensorEvent e)
        {
            int level = (int)e.Values[0];

            m_mauiService.SetTempLevel(level);
            //m_mauiService.DrawTempLevel(level);
        }

        public void StartTempSensor()
        {

            if (m_sensorManager == null)
            {
                m_sensorManager = MainActivity.m_sensorManager;
                m_sensor = m_sensorManager.GetDefaultSensor(SensorType.Light);
            }

            m_sensorManager.RegisterListener(this, m_sensor, SensorDelay.Ui);
        }

        public void StopTempSensor()
        {
            //throw new NotImplementedException();
            m_sensorManager.UnregisterListener(this);
        }

        public void TransferObject(MauiService service)
        {
            m_mauiService = service;
        }
    }
}
