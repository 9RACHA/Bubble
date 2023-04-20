using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {
    private static float topLimit = 5;
    private static float leftLimit = -3;
    private static float rightLimit = 3;

    private static float gridLeg = 0.8f; //0.77f;
    private static float gridHeightFactor = 0.866f;
    private static float gridEfectiveHeight = gridLeg*gridHeightFactor;
    private static Vector3 gridAnchor = new Vector3 (0, topLimit-gridLeg/2 ,0);

    
    
    public static Vector3 NearestGridPoint(Vector3 position) {
        Vector3 gridPoint;
        Vector3 nearestPoint = new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity) ;
        float sqrMinDistance = Mathf.Infinity;
        for(int i=-5; i<5; i++) {
            for(int j=0; j<20; j++) {
                gridPoint =  Grid.GridPoint(i, j);
                if(gridPoint.x != Mathf.Infinity) {
                    float sqrDistance = SqrDistance(position, gridPoint);
                    if(sqrDistance < sqrMinDistance) {
                        nearestPoint = gridPoint;
                        sqrMinDistance = sqrDistance;
                    }

                }
            }
        }

        nearestPoint.z = position.z;
        return nearestPoint;
        /*
        float rowIndex = (position.y - gridAnchor.y) / gridEfectiveHeight;
        float upperRowY = Mathf.Ceil(rowIndex) * gridEfectiveHeight + gridAnchor.y;
        float lowerRowY = Mathf.Floor(rowIndex) * gridEfectiveHeight + gridAnchor.y;

        float upperRowX = NearestGridXCoordinate(position.x, upperRowY);
        float lowerRowX = NearestGridXCoordinate(position.x, lowerRowY);

        Vector3 candidatePoint1 = new Vector3(upperRowX, upperRowY, position.z);
        Vector3 candidatePoint2 = new Vector3(lowerRowX, lowerRowY, position.z);

        if( (position-candidatePoint1).sqrMagnitude < (position-candidatePoint2).sqrMagnitude ) {
            return candidatePoint1;
        }
        return candidatePoint2;
        */
    }

    private static float NearestGridXCoordinate(float positionX, float rowY) {


        /*
        float columnIndex;
        float oddRowOffset = 0;
        if(IsEvenRow(rowY)) {
            //Debug.Log("Fila par");
            columnIndex = (positionX - gridAnchor.x) / gridLeg;
        } else {
            //Debug.Log("Fila impar");
            columnIndex = (positionX - (gridAnchor.x - gridLeg/2)) / gridLeg;
            oddRowOffset = gridLeg/2;
        }

        float leftmostX = Mathf.Floor(columnIndex) * gridLeg + oddRowOffset;
        if(positionX < rightLimit-gridLeg/2) {
            return leftmostX;
        }

        float rightmostX = Mathf.Ceil(columnIndex) * gridLeg + oddRowOffset;
        if(positionX > leftLimit+gridLeg/2) {
            return rightmostX;
        }

        if(Mathf.Abs(leftmostX-positionX) < Mathf.Abs(rightmostX-positionX)) {
            //Si nos pasamos de límites por la izquierda devolvemos el punto de la derecha
            if(leftmostX < leftLimit+gridLeg/2 + oddRowOffset) {
                return rightmostX;
            }
            return leftmostX;
        }
        //Si nos pasamos de límites por la derecha devolvemos el punto de la derecha
        if(rightmostX > rightLimit-(gridLeg/2+ oddRowOffset)) {
            Debug.Log("NearestGridXCoordinate coordenada x descartada " + rightmostX + " coordenada x devolta " + leftmostX );
            return leftmostX;
        }
        return rightmostX;
        */
        //Fake return para evitar error de sintaxis
        return 0;
    }

    private static float SqrDistance(Vector3 a, Vector3 b) {
        return (a-b).sqrMagnitude;
    }

    private static bool IsEvenRow(float rowY) {
        //Debug.Log("IsEvenRow " + (rowY-gridAnchor.y) / gridEfectiveHeight / 2 + " " + Mathf.Round((rowY-gridAnchor.y) / gridEfectiveHeight / 2));
        float evenCalculatedRowY = Mathf.Round((rowY-gridAnchor.y) / gridEfectiveHeight / 2) * 2 * gridEfectiveHeight + gridAnchor.y;

        //Debug.Log("IsEvenRow " + evenCalculatedRowY + " " + rowY);
        return Mathf.Abs(evenCalculatedRowY - rowY) < 0.005;
    } 

    public static Vector3 GridPoint(int i, int j) {
        float y = gridAnchor.y - j*gridEfectiveHeight;
        float x = gridAnchor.x + i*gridLeg;
        if(j % 2 > 0) {
            x += gridLeg/2;
        }

        if(x < leftLimit+gridLeg/2 || x > rightLimit-gridLeg/2) {
            return new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);
        } 

        return new Vector3(x, y, 0);
    }

}



