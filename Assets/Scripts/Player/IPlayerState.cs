/**********************************************************
 *
 *  IPlayerState.cs
 *  �v���C���[�̃X�e�[�g�C���^�t�F�C�X
 *
 *  ����� : ���X ����
 *  ����� : 2025/03/30
 *
 *********************************************************/

public interface IPlayerState
{
    public void OnEnter();     //	�X�e�[�g�ɓ������Ƃ��̏���
    public void Update();      //	�X�e�[�g�̍X�V����
    public void OnExit();		//	�X�e�[�g�𔲂���Ƃ��̏���
}
