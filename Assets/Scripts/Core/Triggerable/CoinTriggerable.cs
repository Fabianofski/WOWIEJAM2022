﻿// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using F4B1.Audio;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core.Triggerable
{
    public class CoinTriggerable : MonoBehaviour, ITriggerable
    {
        [SerializeField] private IntVariable strokes;
        [SerializeField] private int coinAmount;
        [SerializeField] private Sound collectCoinSound;
        [SerializeField] private GameObject coinParticle;
        [SerializeField] private SoundEvent playSoundEvent;
        private CircleCollider2D _circleCollider2D;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _circleCollider2D = GetComponent<CircleCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            playSoundEvent.Raise(collectCoinSound);
            Destroy(Instantiate(coinParticle, transform.position, Quaternion.identity), 1f);
            strokes.Value += coinAmount;
            Destroy(gameObject);
        }

        public void Trigger(float offset)
        {
            Invoke(nameof(SetCoinActive), offset);
        }

        public void Trigger(bool ballIsStill)
        {
            if (ballIsStill) SetCoinActive();
        }

        private void SetCoinActive()
        {
            GetComponent<Animator>().SetTrigger("FadeIn");
            _spriteRenderer.enabled = true;
            _circleCollider2D.enabled = true;
        }
    }
}