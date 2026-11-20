package com.scanflow.datacapture.barinternal.org.ddogleg.struct;

import java.util.ArrayDeque;

/* JADX INFO: loaded from: classes3.dex */
public class DogLinkedList {
    protected final ArrayDeque available = new ArrayDeque();
    protected Element first;
    protected Element last;
    protected int size;

    public void reset() {
        Element element = this.first;
        while (element != null) {
            Element element2 = element.next;
            element.clear();
            this.available.add(element);
            if (element2 == this.first) {
                break;
            } else {
                element = element2;
            }
        }
        this.last = null;
        this.first = null;
        this.size = 0;
    }

    public Element pushTail(Object obj) {
        Element elementRequestNew = requestNew();
        elementRequestNew.object = obj;
        Element element = this.last;
        if (element == null) {
            this.last = elementRequestNew;
            this.first = elementRequestNew;
        } else {
            elementRequestNew.prev = element;
            element.next = elementRequestNew;
            this.last = elementRequestNew;
        }
        this.size++;
        return elementRequestNew;
    }

    public Element insertAfter(Element element, Object obj) {
        Element elementRequestNew = requestNew();
        elementRequestNew.object = obj;
        elementRequestNew.prev = element;
        Element element2 = element.next;
        elementRequestNew.next = element2;
        if (element2 != null) {
            element2.prev = elementRequestNew;
        } else {
            this.last = elementRequestNew;
        }
        element.next = elementRequestNew;
        this.size++;
        return elementRequestNew;
    }

    public void remove(Element element) {
        Element element2 = element.next;
        if (element2 == null) {
            this.last = element.prev;
        } else {
            element2.prev = element.prev;
        }
        Element element3 = element.prev;
        if (element3 == null) {
            this.first = element2;
        } else {
            element3.next = element2;
        }
        this.size--;
        element.clear();
        this.available.add(element);
    }

    public Element getHead() {
        return this.first;
    }

    public Element getTail() {
        return this.last;
    }

    public int size() {
        return this.size;
    }

    protected Element requestNew() {
        if (this.available.isEmpty()) {
            return new Element();
        }
        return (Element) this.available.pop();
    }

    public static class Element {
        public Element next;
        public Object object;
        public Element prev;

        public void clear() {
            this.next = null;
            this.prev = null;
            this.object = null;
        }
    }
}
