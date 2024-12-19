using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [System.Serializable]
    public struct PuzzleMapping
    {
        public GameObject puzzleObject;
        public List<GameObject> reactiveObjects;
    }

    [SerializeField]
    private List<PuzzleMapping> puzzleMapping = null;

    /// <summary>
    /// Key ���� ������ Ǯ���� List�� �������� IReactToPuzzle�� ������ ������Ʈ���� ��ȭ�Ѵ�.
    /// </summary>
    private Dictionary<IPuzzleObject, List<IReactToPuzzle>> puzzleMap = null;

    private void Awake()
    {
        puzzleMap = new Dictionary<IPuzzleObject, List<IReactToPuzzle>>();
    }

    private void Start()
    {
        InitializePuzzleMap(puzzleMapping);
    }

    public void OnSolvePuzzle(IPuzzleObject puzzleObject)
    {
        List<IReactToPuzzle> reactComps = puzzleMap[puzzleObject];

        foreach (var reactToSolve in reactComps)
        {
            reactToSolve.OnPuzzleSolved();
        }
    }

    /// <summary>
    /// puzzleMapping Ŭ���� ����Ʈ�� ������ ���� puzzmeMap ��ųʸ��� �ʱ�ȭ�ϴ� �Լ�.
    /// </summary>
    /// <param name="_mappings">puzzleMapping Ŭ���� ����Ʈ</param>
    private void InitializePuzzleMap(List<PuzzleMapping> _mappings)
    {
        foreach (PuzzleMapping mapping in _mappings)
        {
            IPuzzleObject puzzleComponent = mapping.puzzleObject.GetComponent<IPuzzleObject>();

            // PuzzleMapping Ŭ������ ���� ������Ʈ�� IPuzzleObject�� �������� ��� ���.
            if (puzzleComponent != null)
            {
                List<IReactToPuzzle> puzzleReactComponents = new List<IReactToPuzzle>();

                foreach (GameObject obj in mapping.reactiveObjects)
                {
                    IReactToPuzzle puzzleReactcomponent = obj.GetComponent<IReactToPuzzle>();

                    if (puzzleReactcomponent != null)
                        puzzleReactComponents.Add(puzzleReactcomponent);
                }
                puzzleMap[puzzleComponent] = puzzleReactComponents;
            }
        }
    }
}
