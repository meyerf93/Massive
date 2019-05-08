using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System;

//[System.Serializable]
//public enum Card {Proton, Neutron};

[System.Serializable]
public enum Type {Composite, Elementary,Events,Elements};

[System.Serializable]
public enum Group {Hadron, Fermion, Bosons};

[System.Serializable]
public enum Classification { Baryon, Lepton, Quark, Gauge};

[System.Serializable]
public class Charge
{
	[XmlElement("Value")]
	public float Value;

	[XmlElement("Unit")]
	public string Unit;
}

[System.Serializable]
public class Mass
{
	[XmlElement("Value")]
    public float Value;

    [XmlElement("Unit")]
    public string Unit;
}

[System.Serializable]
public class InteractionElement
{
	[XmlElement("IntercationElement")]
	public string IntercationElement;
}


[System.Serializable]
public class ComposerElement
{
	[XmlElement("Name")]
	public string Name;

	[XmlElement("Number")]
	public int Number;
}

[System.Serializable]
public class Characteristics
{
	[XmlElement("Generation")]
	public string Generation;

	[XmlArray("Compositions")]
	[XmlArrayItem("ComposerElement")]
	public List<ComposerElement> Compositions = new List<ComposerElement>();

	[XmlArray("Interactions")]
	[XmlArrayItem("InteractionElement")]
	public List<InteractionElement> Interactions = new List<InteractionElement>();

	[XmlElement("Location")]
	public string Location;

	[XmlElement("ScientificNotation")]
	public string ScientificNotation;
    
	[XmlElement("Charge")]
	public Charge Charge;

	[XmlElement("Mass")]
	public Mass Mass;

	[XmlElement("Spin")]
	public string Spin;
}
/*
      <Characteristics>
        <Generation>First</Generation>
        <Composition>
          <ComposerElement>
            <Name>Up Quark</Name>
            <Number>2</Number>
          </ComposerElement>
          <ComposerElement>
            <Name>Down Quark</Name>
            <Number>1</Number>
          </ComposerElement>
        </Composition>
        <Interactions>
          <IntercationElement>Strong Force</InteractionElement>
          <IntercationElement>Weak Positive Force</InteractionElement>
          <IntercationElement>Weak Negative Force</InteractionElement>
        </Interactions>
        <Location>Nucleus-space</Location>
        <ScientificNotation>p+</ScientificNotation>
        <Charge>+1 e</Charge>
        <Mass>938.2720813(58) MeV/c2</Mass>
        <Spin>1/2</Spin>
      </Characteristics>
*/
[System.Serializable]
public class Media
{
	[XmlElement("Image")]
	public string Image;
}
[System.Serializable]
public class Card
{
	[XmlElement("Description")]
	public string Description;

	[XmlElement("Type")]
	public Type Type;

	[XmlElement("Group")]
	public Group group;

	[XmlElement("Classification")]
	public Classification Classification;
    
	[XmlElement("Characteristics")]
	public Characteristics Characteristics;

	[XmlElement("Media")]
	public Media Media;
}

/*
<?xml version="1.0" encoding="utf-8"?>
<Game Name="Massive, a game of four forces" Version="0.0.1">
  <Cards>
    <!-- Proton -->
    <Card Name="Proton">
      <!-- Description -->
      <Description>This card represents a proton. It resides in the nucleus-space.</Description>
      <!-- Characteristics -->
      <Type>Composite</Type>
      <Group>Hadron</Group>
      <Classification>Baryon</Classification>

      <Characteristics>
        <Generation>First</Generation>
        <Composition>
          <Card>Up Quark</Card>
          <Card>Up Quark</Card>
          <Card>Down Quark</Card>
        </Composition>
        <Interactions>
          <Card>Strong Force</Card>
          <Card>Weak Positive Force</Card>
          <Card>Weak Negative Force</Card>
        </Interactions>
        <Location>Nucleus-space</Location>
        <ScientificNotation>p+</ScientificNotation>
        <Charge>+1 e</Charge>
        <Mass>938.2720813(58) MeV/c2</Mass>
        <Spin>1/2</Spin>
      </Characteristics>
      <!-- Media -->
      <Media>
        <Image Type="Traker">Cards/Baryons/BaryonCard_Proton01.jpg</Image>
      </Media>
    </Card>

*/

[XmlRoot("Game")]
public class ConfigScene
{
    
    [XmlArray("Cards")]
    [XmlArrayItem("Card")]
    public List<Card> Cards = new List<Card>();

    public static ConfigScene Load(string path)
	{
		try
		{   XmlRootAttribute xmlRoot = new XmlRootAttribute();
            xmlRoot.ElementName = "Game";
            xmlRoot.IsNullable = true;
            			
			Debug.Log(path);
			XmlSerializer serializer = new XmlSerializer(typeof(ConfigScene), xmlRoot);
			using (StreamReader reader = new System.IO.StreamReader(path))
            {
                return serializer.Deserialize(reader.BaseStream) as ConfigScene;
            }
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError("Exception loading config file: " + e);

            return null;
        }
    }
}
/*using UnityEngine;
 using System.Collections.Generic;
 using System.Xml;
 using System.Xml.Serialization;
 using System.IO;
 using System;
 
 public struct Montage
{
    [XmlElement("questionText")]
    public string questionText;

    [XmlElement("answer")]
    public string answer;
}

[XmlRoot("Questions"), XmlType("Questions")]
public class ConfigScene
{

    [XmlArray("Questions")]
    [XmlArrayItem("Question")]
    public List<Montage> questions = new List<Montage>();

    public static ConfigScene Load(string path)
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigScene));
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return serializer.Deserialize(stream) as ConfigScene;
            }
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError("Exception loading config file: " + e);

            return null;
        }
    }
}*/